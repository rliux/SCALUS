﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace scalus.Dto
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Platform
    {
        Windows =0,
        Linux=1,
        Mac=2
    }

    public class ApplicationConfig
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Platform> Platforms { get; set; }
        public string Protocol { get; set; }
        public ParserConfig Parser { get; set; }
        public string Exec { get; set; }
        public List<string> Args { get; set; }

        private static Dictionary<string, string> _dtoPropertyDescription = new Dictionary<string, string>
        {
            {"Id","The unique identifier"},
            {"Name","User-friendly name"},
            {"Description","Optional description of this application"},
            {"Platforms","The list of platforms supported for this application. Valid values are: TODO"},
            {"Protocol","The protocol supported for this application"},
            {"Parser","The parser that will be used to interpret the URL. The available values are: 'rdp', 'ssh', 'telnet', 'url'.url can be used to interpret any standard URL."},
            {"Exec","The full path to the command to run. This can contain any of the supported tokens."},
            {"Args","The list of arguments to pass to the command. This can contain any of the supported tokens."}
        };
        public static Dictionary<string, string> DtoPropertyDescription => _dtoPropertyDescription.Append(ParserConfig.DtoPropertyDescription);

        public void Validate()
        {
            Id.NotNullValue(nameof(Id));
            Protocol.NotNullValue(nameof(Protocol));
            Exec.NotNullValue(nameof(Exec));
            Parser.Validate();
        }
    }
}
