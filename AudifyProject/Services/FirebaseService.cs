using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AudifyProject.Services
{
    public class FirebaseService : IFirebaseService
    {
        public static string ApiKey = "AIzaSyC6nAdVQPvD0s_LK01ETYGluLmVpDO90sw";
        public static string Bucket = "audify-9422d.appspot.com";
        public static string AuthUserName = "audifyadmin@gmail.com";
        public static string AuthUserPassword = "Audify@2022";
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FirebaseService> _logger;

        public FirebaseService(IWebHostEnvironment env, ILogger<FirebaseService> logger)
        {
            _env = env;
            _logger = logger;
        }

        public async Task<string> UploadAudio(IFormFile file)
        {
            string localAudioFolderName = "Audio";
            string firebaseFileUrl = String.Empty;
            try
            {
                string path = Path.Combine(_env.WebRootPath, localAudioFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Save file first to local directory
                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var localFullFilePath = Path.Combine(path, uniqueFileName);
                using (FileStream fs = new FileStream(localFullFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    await file.CopyToAsync(fs); // Save file


                }

                // Delete local file
              
                return uniqueFileName;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

            public async Task<string> UploadFile(IFormFile file)
        {
            string localTempFolderName = "temp";
            string firebaseFileUrl = String.Empty;
            try
            {
                string path = Path.Combine(_env.WebRootPath, localTempFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Save file first to local directory
                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var localFullFilePath = Path.Combine(path, uniqueFileName);
                using (FileStream fs = new FileStream(localFullFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    await file.CopyToAsync(fs); // Save file

                    // Read file from local
                    using (FileStream ms = new FileStream(localFullFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        // Upload file to Firebase's FileStorage
                        var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                        var a = await auth.SignInWithEmailAndPasswordAsync(AuthUserName, AuthUserPassword);
                        var cancellation = new CancellationTokenSource();
                        var task = new FirebaseStorage(
                            Bucket,
                            new FirebaseStorageOptions
                            {
                                HttpClientTimeout = TimeSpan.FromMinutes(30),
                                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                        })
                        .Child("Audios")
                        .Child(uniqueFileName)
                        .PutAsync(ms, cancellation.Token);

                        firebaseFileUrl = await task;
                    }
                }

                // Delete local file
                File.Delete(localFullFilePath);
                return firebaseFileUrl;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
            

           
        }

        public async Task<string> UploadProfile(IFormFile file)
        {
            string localAudioFolderName = "Profile";
            string firebaseFileUrl = String.Empty;
            try
            {
                string path = Path.Combine(_env.WebRootPath, localAudioFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Save file first to local directory
                var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var localFullFilePath = Path.Combine(path, uniqueFileName);
                using (FileStream fs = new FileStream(localFullFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    await file.CopyToAsync(fs); // Save file


                }

                // Delete local file

                return uniqueFileName;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }
    }
}
