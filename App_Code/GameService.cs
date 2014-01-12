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
        metadata.Players = new List<PlayerMetadata> {
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=50, Top=240, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=90, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=390, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=90, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=390, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=320, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=320, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser},

            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=670, Top=240, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=90, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=290, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=390, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=90, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=290, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=390, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=400, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag=Guid.NewGuid(), BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=400, Top=290, SolidColor="Blue", IsOpponent=isFirstUser},
        };
        return GetJsonString(metadata);

    }

    [OperationContract]
    public void SetMoveMetadata(string gameId, string userId, string metadata, int currentMoveNumber)
    {
        DbHelper.SetMoveMetadata(gameId, userId, metadata, currentMoveNumber);
    }

    public string GetMoveMetadata(string gameId, string userId)
    {
        return null;
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
    //Убрать этот метод после реализации метаданных в БД
    private byte Random()
    {
        Random r = new Random(Environment.TickCount);
        return (byte)r.Next(50, 100);
    }
}

public class Metadata
{
    public List<PlayerMetadata> Players { get; set; }
}
public class PlayerMetadata
{
    public Guid Tag { get; set; }
    public string SolidColor { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public bool IsOpponent { get; set; }
    public byte Run { get; set; }
    public byte ShortPass { get; set; }
    public byte LongPass { get; set; }
    public byte Shoot { get; set; }
    public byte ShortPassAccuracy { get; set; }
    public byte LongPassAccuracy { get; set; }
    public byte ShootAccuracy { get; set; }
    public byte Power { get; set; }
    public byte Speed { get; set; }
    public byte Stamina { get; set; }
    public byte BodyBalance { get; set; }
    public byte BallControl { get; set; }
}
