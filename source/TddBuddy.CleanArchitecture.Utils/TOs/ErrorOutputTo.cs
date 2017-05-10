using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TddBuddy.CleanArchitecture.Utils.TOs
{
    public class ErrorOutputTo
    {
        [JsonIgnore]
        public bool HasErrors => _errors.Any();

        private readonly List<string> _errors;

        public ErrorOutputTo()
        {
            _errors = new List<string>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }

        public List<string> FetchErrors()
        {
            return _errors;
        }
    }
}