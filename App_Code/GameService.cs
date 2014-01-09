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
        //Из БД будет возвращатся коллекция, в качестве ключа будет имя свойства, а в качестве значения таблица
        //на две колонки. Первая - для П1, вторая - для П2
        bool isFirstUser = DbHelper.IsFirstUser(gameId, userId);
        Metadata metadata = new Metadata();
        //Создавать через foreach, когда будет вытягиваться коллекция из БД
        metadata.Players = new[] {
            new PlayerMetadata { Left=50, Top=240, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=120, Top=90, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=120, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=120, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=120, Top=390, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=220, Top=90, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=220, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=220, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=220, Top=390, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=320, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Left=320, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser},

            new PlayerMetadata { Left=670, Top=240, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=600, Top=90, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=600, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=600, Top=290, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=600, Top=390, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=500, Top=90, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=500, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=500, Top=290, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=500, Top=390, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=400, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Left=400, Top=290, SolidColor="Blue", IsOpponent=isFirstUser},
        };
        return GetJsonString(metadata);

    }
    private string GetJsonString(Metadata metadata)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(metadata.GetType());
            stream.Position = 0;
            serializer.WriteObject(stream, metadata);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

public class Metadata
{
    public IEnumerable<PlayerMetadata> Players { get; set; }
}
public class PlayerMetadata
{
    public string SolidColor { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public bool IsOpponent { get; set; }
}
