/*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at https://mozilla.org/MPL/2.0/.
*
* Copyright (c) 2025 Florian K.
*
*/

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace LibreDiagnostics.Models.Helper
{
    internal class IPAddressHelper
    {
        #region Fields

        const string IPIFY = "https://api.ipify.org";

        const string _RegexString = @"[^\w\d\s]";

        #endregion

        #region Public

        public static string GetAdapterIPAddress(string name)
        {
            string configuredName = Regex.Replace(name, _RegexString, string.Empty);

            //Go through network interfaces
            foreach (var network in NetworkInterface.GetAllNetworkInterfaces())
            {
                var description   = Regex.Replace(network.Description, _RegexString, string.Empty);
                var nameInterface = Regex.Replace(network.Name, _RegexString, string.Empty);

                if (description == configuredName || nameInterface == configuredName)
                {
                    var properties = network.GetIPProperties();

                    foreach (var unicast in properties.UnicastAddresses)
                    {
                        if (unicast.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return unicast.Address.ToString();
                        }
                    }
                }
            }

            return null;
        }

        public static string GetExternalIPAddress()
        {
            try
            {
                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromSeconds(5);

                using var response = http.GetAsync(IPIFY);
                var content = response.Result.Content.ReadAsStringAsync();

                return content.Result;
            }
            catch (WebException)
            {
                //Ignore
                return string.Empty;
            }
        }

        #endregion
    }
}
