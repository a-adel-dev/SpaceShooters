using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Utils
{
    // public class ConfigDataContainer
    // {
    //     public float BeeRotationSpeed { get; set; }
    //     public float BeeThrustSpeed { get; set; }
    //     public int BeeHealth { get; set; }
    // }
    //
    // public class ConfigDataReader
    // {
    //     private const string ConfigurationDataFileName = "ConfigData.json";
    //     private ConfigDataContainer DataContainer { get; set; } = new ConfigDataContainer();
    //
    //     public void LoadJson()
    //     {
    //         using StreamReader file =
    //             new StreamReader(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
    //         JsonSerializer serializer = new JsonSerializer();
    //         DataContainer = (ConfigDataContainer) serializer.Deserialize(file, typeof(ConfigDataContainer));
    //         MapToStaticClass(DataContainer);
    //     }
    //
    //
    //     void MapToStaticClass(ConfigDataContainer source)
    //     {
    //         var sourceProperties = source.GetType().GetProperties();
    //         
    //         //specify we want only static properties
    //         var destinationProperties = typeof(ConfigData)
    //             .GetProperties(BindingFlags.Public | BindingFlags.Static);
    //
    //         foreach (var prop in sourceProperties)
    //         {
    //             //Find Matching property by name
    //             var destinationProp = destinationProperties.Single(p => p.Name == prop.Name);
    //             //Set the static property value
    //             destinationProp.SetValue(null, prop.GetValue(source));
    //         }
    //     }
    // }
}
