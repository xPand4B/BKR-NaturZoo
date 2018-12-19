using System;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides <see cref="Log"/> data.
    /// </summary>
    public class Log : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        public Log()
        {
            // Set default values
            Status = status.None;
            Message = "Default Log Message.";
        }

        public enum status
        {
            None,
            Info,
            Update,
            Error
        }

        public status Status { get; set; }

        public String Message { get; set; }
    }
}
