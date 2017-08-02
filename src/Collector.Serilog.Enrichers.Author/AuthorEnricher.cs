namespace Collector.Serilog.Enrichers.Author
{
    using System;
    using System.Collections.Generic;

    using global::Serilog.Core;
    using global::Serilog.Events;

    public class AuthorEnricher : ILogEventEnricher
    {
        private readonly IDictionary<string, string> _dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorEnricher"/> class.
        /// </summary>
        /// <param name="teamName">Team (e.g. "Heimdal" or "Ace of Space")</param>
        /// <param name="department">Department (e.g. "Payments" or "Solutions")</param>
        /// <param name="repositoryUrl">Repository (The url to where the source code can be found)</param>
        /// <param name="serviceGroup">ServiceGroup (If this service is part of a larger group of services, then the name of that group, e.g. "Edge" or "Loans")</param>
        public AuthorEnricher(string teamName, string department, Uri repositoryUrl = null, string serviceGroup = null)
        {
            if (teamName == null)
                throw new ArgumentNullException(nameof(teamName));
            if (department == null)
                throw new ArgumentNullException(nameof(department));

            _dictionary = new Dictionary<string, string>
                          {
                              ["Team"] = teamName,
                              ["Department"] = department
                          };

            if (repositoryUrl != null)
                _dictionary["Repository"] = repositoryUrl.ToString();

            if (serviceGroup != null)
                _dictionary["ServiceGroup"] = serviceGroup;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Author", _dictionary, destructureObjects: true));
        }
    }
}