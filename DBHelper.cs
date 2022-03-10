using CoinCalculatorAPI.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace CoinCalculatorAPI
{
    public class DBHelper
    {
        private KindOfADatabase db;
        public DBHelper()
        {
            db = new KindOfADatabase();
        }

        public bool Login(Credentials creds)
        {
            
            return db.LoginUser( creds ) != null;
        }

        public Wallet GetUserWallet(User user)
        {
            return new Wallet();
        }

        public bool AddUser(User user)
        {
            if(db.FindUser(user) == null)
            {
                db.AddUser( user ); 
                return true;
            }
            else
            {
                //someone here with that name already
                return false;
            }
        }

        public bool AddCoin(User user, Coin coin)
        {
            //Someone find this guys wallet and fill it
            user = db.AddCoin( user, coin );
            
            return user != null;
        }

        public bool RemoveCoin( User user, Coin coin )
        {
            //Someone find this guys wallet and fill it
            user = db.RemoveCoin( user, coin );

            return user != null;
        }
    }

    public class KindOfADatabase
    {
        public KindOfADatabase()
        {
            string fileName = "totallyADataBase.json";
            string jsonString = File.ReadAllText( fileName );
            AllMyData = JsonSerializer.Deserialize<List<User>>( jsonString )!;
        }

        private List<User> AllMyData { get; set; }

        public User FindUser(User user)
        {
            User temp = AllMyData.Where( usr => usr.username == user.username ).First() ?? null;
            return temp;
        }
        public User LoginUser( Credentials creds )
        {
            User temp = AllMyData.Where( usr => (usr.username == creds.user && usr.password == creds.password)).First() ?? null;
            return temp;
        }

        private async void SaveDataBase()
        {
            string fileName = "totallyADatabase.json";
            using FileStream createStream = File.Create( fileName );
            await JsonSerializer.SerializeAsync( createStream, AllMyData );
            await createStream.DisposeAsync();
        }

        internal void AddUser( User user )
        {
            AllMyData.Add( user );
            SaveDataBase();
        }
        
        //Destructive read
        public User FindandRemoveUser( User user )
        {
            User temp = AllMyData.Where( usr => usr.username == user.username ).First() ?? null;
            if(temp != null)
            {
                AllMyData.Remove( temp );
            }
            return temp;
        }

        public User AddCoin( User user, Coin coin )
        {
            //Grab and remove current record, don't trust changes to propagate through to list otherwise
            User temp = FindandRemoveUser( user );
            if(temp != null )
            {
                temp.wallet.Coins.Add( coin );
                AllMyData.Add( temp );
                SaveDataBase();
            }
            return temp;
        }

        internal User RemoveCoin( User user, Coin coin )
        {
            //Grab and remove current record, don't trust changes to propagate through to list otherwise
            User temp = FindandRemoveUser( user );
            if( temp != null )
            {
                Coin tempcoin = temp.wallet.Coins.Where( con => con.symbol == coin.symbol ).First();
                temp.wallet.Coins.Remove( tempcoin );
                AllMyData.Add( temp );
                SaveDataBase();
            }
            return temp;
        }
    }
}
