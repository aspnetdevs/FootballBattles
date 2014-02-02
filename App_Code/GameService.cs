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
            new PlayerMetadata { Tag="a1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=50, Top=240, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="b1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=90, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="c1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="d1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="e1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=120, Top=390, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="f1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=90, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="g1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="h1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="i1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=220, Top=390, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="j1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=320, Top=190, SolidColor="Yellow", IsOpponent=!isFirstUser },
            new PlayerMetadata { Tag="k1", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=320, Top=290, SolidColor="Yellow", IsOpponent=!isFirstUser},

            new PlayerMetadata { Tag="a2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=670, Top=240, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="b2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=90, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="c2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="d2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=290, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="e2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=600, Top=390, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="f2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=90, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="g2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="h2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=290, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="i2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=500, Top=390, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="j2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=400, Top=190, SolidColor="Blue", IsOpponent=isFirstUser },
            new PlayerMetadata { Tag="k2", BallControl=Random(), BodyBalance=Random(), LongPass=Random(), LongPassAccuracy=Random(), Power=Random(), Run=Random(), Shoot=Random(), ShootAccuracy=Random(), ShortPass=Random(), ShortPassAccuracy=Random(), Speed=Random(), Stamina=Random(),Left=400, Top=290, SolidColor="Blue", IsOpponent=isFirstUser},
        };
        return GetJsonString(metadata);

    }

    [OperationContract]
    public void SetMoveMetadata(string gameId, string userId, string metadata, int currentMoveNumber)
    {
        DbHelper.SetMoveMetadata(gameId, userId, metadata, currentMoveNumber);
    }

    [OperationContract]
    public string GetMoveMetadata(string gameId, string userId)
    {
        return DbHelper.GetMoveMetadata(gameId, userId);
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
    private double Random()
    {
        Random r = new Random((int)Math.Pow(Environment.TickCount, 4));
        return (double)r.Next(50, 100);
    }
}

public class Metadata
{
    public List<PlayerMetadata> Players { get; set; }
}
public class PlayerMetadata
{
    public string Tag { get; set; }
    public string SolidColor { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public bool IsOpponent { get; set; }
    public double Run { get; set; }
    public double ShortPass { get; set; }
    public double LongPass { get; set; }
    public double Shoot { get; set; }
    public double ShortPassAccuracy { get; set; }
    public double LongPassAccuracy { get; set; }
    public double ShootAccuracy { get; set; }
    public double Power { get; set; }
    public double Speed { get; set; }
    public double Stamina { get; set; }
    public double BodyBalance { get; set; }
    public double BallControl { get; set; }
}
