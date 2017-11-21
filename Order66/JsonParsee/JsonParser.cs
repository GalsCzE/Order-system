using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order66.Interface;
using Newtonsoft.Json;

namespace Order66.JsonParsee
{
    class JsonParser : IParse
    {
        public async Task<T> ParseString<T>(string response)
        {
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response));
        }
    }
}
