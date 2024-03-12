using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Realms;
using Realms.Sync;
using Realms.Sync.Exceptions;
using System.Threading.Tasks;

public class RealmController : MonoBehaviour
{
    public static RealmController Instance;

    public string RealmAppId = "racing-game-vdizg";

    private Realm _realm;
    private App _realmApp;
    private User _realmUser;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void OnDisable()
    {
        if(_realm != null)
        {
            _realm.Dispose();
        }
    }

    public async Task<string> Login(string username, string password) 
    {
        if (username != "" && password != "")
        {
            _realmApp = App.Create(new AppConfiguration(RealmAppId)
            {
                MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
            });
            try
            {
                if (_realmUser == null)
                {
                    _realmUser = await _realmApp.LogInAsync(Credentials.EmailPassword(username, password));
                    _realm = await Realm.GetInstanceAsync(new SyncConfiguration(username, _realmUser));
                }
                else
                {
                    _realm = Realm.GetInstance(new SyncConfiguration(username, _realmUser));
                }
            }
            catch (ClientResetException clientResetEx)
            {
                if (_realm != null)
                {
                    _realm.Dispose();
                }
                clientResetEx.InitiateClientReset();
            }
            return _realmUser.Id;
        }
        return "";
    }

    public PlayerInfo GetPlayerInfo() 
    {
        PlayerInfo _playerProfile = _realm.Find<PlayerInfo>(_realmUser.Id);
        if (_playerProfile == null)
        {
            _realm.Write(() => {
                _playerProfile = _realm.Add(new PlayerInfo(_realmUser.Id));
            });
        }
        return _playerProfile;
    }

    
}
