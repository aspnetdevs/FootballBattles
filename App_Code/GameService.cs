using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

[ServiceContract]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class GameService
{
    [OperationContract]
    public string GetStartMetadata(string gameId, string userId)
    {
        //Пока генерирует метаданные производные
        Metadata metadata = new Metadata();
        metadata.Players = new[] { 
            new PlayerMetadataElement { ElementPlayerName="Player1", Left=20, Top=40 },
            new PlayerMetadataElement { ElementPlayerName="Player2", Left=50, Top=80 },
            new PlayerMetadataElement { ElementPlayerName="Player2", Left=150, Top=280 }
        };
        return GetJsonString(metadata);
        
    }
    private string GetJsonString(Metadata metadata)
    {
        using (MemoryStream stream = new MemoryStream()) {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(metadata.GetType());
            stream.Position = 0;
            serializer.WriteObject(stream, metadata);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

public class Metadata
{
    public IEnumerable<PlayerMetadataElement> Players { get; set; }
}
public class PlayerMetadataElement
{
    public string ElementPlayerName { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
}
