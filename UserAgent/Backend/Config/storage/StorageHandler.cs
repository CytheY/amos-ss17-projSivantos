using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;

namespace RaspberryBackend
{
    /// <summary>
    /// Adaptedion of <see cref="https://stackoverflow.com/questions/34385625/saving-files-on-raspberry-pi-with-windows-iot"/>
    /// Provides functions to save and load single object as well as List of 'T' using serialization
    /// </summary>
    /// <typeparam name="T">Type parameter to be serialize</typeparam>
    public static class StorageHandler<T> where T : new()
    {
        public static async Task Save(string FileName, T _Data)
        {
            MemoryStream _MemoryStream = new MemoryStream();
            DataContractSerializer Serializer = new DataContractSerializer(typeof(T));
            Serializer.WriteObject(_MemoryStream, _Data);

            Task.WaitAll();

            StorageFolder docfolder = await KnownFolders.GetFolderForUserAsync(null, KnownFolderId.DocumentsLibrary);
            StorageFolder folder = await docfolder.CreateFolderAsync(StorageCfgs.FolderName_Cfgs, CreationCollisionOption.OpenIfExists);
            StorageFile _File = await folder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);


            using (Stream fileStream = await _File.OpenStreamForWriteAsync())
            {
                _MemoryStream.Seek(0, SeekOrigin.Begin);
                await _MemoryStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                fileStream.Dispose();
            }
        }


        public static async Task<T> Load(string FileName)
        {
            StorageFolder docfolder = await KnownFolders.GetFolderForUserAsync(null, KnownFolderId.DocumentsLibrary);
            StorageFolder _Folder = await docfolder.CreateFolderAsync(StorageCfgs.FolderName_Cfgs, CreationCollisionOption.OpenIfExists);

            StorageFile _File;
            T Result;

            try
            {
                Task.WaitAll();
                _File = await _Folder.GetFileAsync(FileName);

                using (Stream stream = await _File.OpenStreamForReadAsync())
                {
                    DataContractSerializer Serializer = new DataContractSerializer(typeof(T));

                    Result = (T)Serializer.ReadObject(stream);

                }
                return Result;
            }
            catch (Exception ex)
            {
                return new T();
            }
        }
    }
}
