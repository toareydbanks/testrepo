using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;

namespace TRISBuildTester
{
   public class StageChanges
    {
        private readonly string _repoSource;
        private readonly UsernamePasswordCredentials _credentials;
        private readonly DirectoryInfo _localFolder;
        private readonly Signature _author;
        private readonly Signature _committer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitRepositoryManager" /> class.
        /// </summary>
        /// <param name="username">The Git credentials username.</param>
        /// <param name="password">The Git credentials password.</param>
        /// <param name="gitRepoUrl">The Git repo URL.</param>
        /// <param name="localFolder">The full path to local folder.</param>
        public StageChanges(string username, string password, string gitRepoUrl, string localFolder)
        {
            _author = null;
            _committer = null;
            var folder = new DirectoryInfo(localFolder);

            if (!folder.Exists)
            {
                throw new Exception(string.Format("Source folder '{0}' does not exist.", _localFolder));
            }

            _localFolder = folder;

            _credentials = new UsernamePasswordCredentials
            {
                Username = username,
                Password = password
            };

            _repoSource = gitRepoUrl;
        }
        public StageChanges(string username, string password, string gitRepoUrl, string localFolder, string author, string committer) : this(username, password, gitRepoUrl, localFolder)
        {
            _author = new Signature(author, "TBanks2@ameren.com", DateTimeOffset.Now);
            _committer = new Signature(committer, "TBanks2@ameren.com", DateTimeOffset.Now);
        }

        /// <summary>
        /// Commits all changes.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.Exception"></exception>
        public void Commit(string message)
        {
            using (var repo = new Repository(_localFolder.FullName))
            {
                var files = _localFolder.GetFiles("*", SearchOption.AllDirectories).Select(f => f.FullName);
                repo.Stage(files);
                var stagecount = repo.Stashes;
                if (_author != null && _committer !=null) {

                    repo.Commit(message, _author,_committer);
                }
                else
                {
                    repo.Commit(message);
                }
                
            }
        }
        public void Commit(string message, string remoteName, string branchName)
        {
            Commit(message);
            Push(remoteName, branchName);
        }
        /// <summary>
        /// Remove all commits.
        /// </summary>
        /// <param name="remoteName">Name of the remote server.</param>
        /// <param name="branchName">Name of the remote branch.</param>
        /// <exception cref="System.Exception"></exception>
        public void Remove(string filename)
        {
            using (var repo = new Repository(_localFolder.FullName))
            {
                repo.Remove(filename, true);
            }
        }

        public void Push(string filename, string remoteName, string branchName)
        {
            Remove(filename);
            Push(remoteName, branchName);

        }
        /// <summary>
        /// Pushes all commits.
        /// </summary>
        /// <param name="remoteName">Name of the remote server.</param>
        /// <param name="branchName">Name of the remote branch.</param>
        /// <exception cref="System.Exception"></exception>
        public void Push(string remoteName, string branchName)
        {
            using (var repo = new Repository(_localFolder.FullName))
            {
                var remote = repo.Network.Remotes.FirstOrDefault(r => r.Name == remoteName);
                if (remote == null)
                {
                    repo.Network.Remotes.Add(remoteName, _repoSource);
                    remote = repo.Network.Remotes.FirstOrDefault(r => r.Name == remoteName);
                }

                var options = new PushOptions
                {
                    CredentialsProvider = (url, usernameFromUrl, types) => _credentials
                };
                var pushRefSpec = @"refs/heads/" + branchName;
                repo.Network.Push(remote, pushRefSpec, options);
            }
        }

    }
}
