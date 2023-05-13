using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailgun.Core.Messages;

namespace Email.Infrastructure.Messages
{
    /// <summary>
    /// Class to represent file attachments loaded from in-memory byte arrays rather than from disk.
    /// </summary>
    public class FileAttachment : IFileAttachment
    {
        /// <summary>
        /// The byte data of the file.
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// The filename of the file to be sent.
        /// </summary>
        public string Name { get; set; }
    }
}
