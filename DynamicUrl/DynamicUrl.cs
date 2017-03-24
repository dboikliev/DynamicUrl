using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamicUrl
{
    public class DynamicUrl : DynamicObject
    {
        private string _url;

        public DynamicUrl(string url)
        {
            _url = url.TrimEnd('/');
        }

        public DynamicUrl this[object parameter]
        {
            get
            {
                _url += string.IsNullOrEmpty(parameter.ToString()) ? string.Empty : "/" + parameter;
                _url = _url.TrimEnd('/');
                return this;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var matches = Regex.Matches(binder.Name, @"\p{Lu}\p{Ll}*");
            var words = new List<string>();
            foreach (var match in matches)
            {
                words.Add(match.ToString().ToLower());
            }
            result = new DynamicUrl(_url + "/" + string.Join("-", words));
            return true;
        }

        public override string ToString()
        {
            return _url;
        }
    }
}
