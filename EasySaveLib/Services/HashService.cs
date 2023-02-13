using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Security.Cryptography;
using EasySaveLib.Models;

namespace EasySaveLib.Services
{
    public class HashService
    {
        public string computeSHA256(
            FileModel fileModel
        )
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(fileModel.FullPath))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", string.Empty);
                }
            }
        }
    }
}
