using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TddBuddy.CleanArchitecture.Utils.TOs
{
    public class ErrorOutputTo
    {
        [JsonIgnore]
        public bool HasErrors => Errors.Any();

        public List<string> Errors { get; }

        public ErrorOutputTo()
        {
            Errors = new List<string>();
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public void AddErrors(List<string> errors)
        {
            Errors.AddRange(errors);
        }
    }
}