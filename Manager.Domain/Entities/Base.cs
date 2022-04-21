using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    /// <summary>
    /// Abstract class, no one can instantiate just inherit
    /// </summary>
    /// 
    public abstract class Base
    {
        public long Id { get; set; }
        internal List<string> _errors;
        /// <summary>
        /// IReadOnly => read only, can't change anything
        /// </summary>
        public IReadOnlyCollection<string> Errors => _errors;
        /// <summary>
        /// Validate => every entity must be independent and able to validate itself
        /// </summary>
        public abstract bool Validade();
    }
}
