using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.core.Messages
{
    public interface IFileAttachment
    {
        /// <summary>
        /// The byte data of the file.
        /// </summary>
        byte[] Data { get; set; }

        /// <summary>
        /// The filename of the file to be sent.
        /// </summary>
        string Name { get; set; }
    }
}
