using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class PhotoProcessor
    {
           public void process(string path, Action<Photo> filterHandler)
            {
                var photo = Photo.Load(path);
                filterHandler(photo);
            }
        
    }
}
