using Arcane.Game.Network;
using Arcane.Game.Helpers;
using Arcane.Protocol.Messages;
using Arcane.Protocol.Enums;
using Arcane.Protocol.Types;
using Arcane.Protocol.Datacenter;
using Dofus.Files.Dofus.Files.Maps;
using Dofus.Files.GameData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcane.Protocol;

namespace Arcane.Game.Wrappers
{
    public class MapWrapper
    {
        public IMapFile TemplateMap { get; }
        public MapPosition TemplateMapPosition { get; }
        public SubArea TemplateSubArea { get; }
        public Area TemplateArea { get; }
        public SuperArea TemplateSuperArea { get; }
        public AlignmentSideEnum AlignmentSide { get; }
        public int Id { get; }

        private List<GameClient> _mClients;
        private Dictionary<GameClient, short[]> movementPaths;
        private Dictionary<GameClient, bool> _mapInfosSent;
        public IReadOnlyCollection<GameClient> Clients { get; }

        public event Action<GameClient> OnClientIncoming;
        public event Action<GameClient> OnClientLeaving;

        public MapWrapper(IMapFile map)
        {
            TemplateMap = map;
            Id = (int)map.Id;
            AlignmentSide = AlignmentSideEnum.ALIGNMENT_NEUTRAL;
            TemplateMapPosition = GameDataManager.Instance.GetObject<MapPosition>(Id);
            TemplateSubArea = GameDataManager.Instance.GetObject<SubArea>(map.SubareaId);
            TemplateArea = GameDataManager.Instance.GetObject<Area>(TemplateSubArea.areaId);
            TemplateSuperArea = GameDataManager.Instance.GetObject<SuperArea>(TemplateArea.superAreaId);
            _mClients = new List<GameClient>();
            Clients = new ReadOnlyCollection<GameClient>(_mClients);
            movementPaths = new Dictionary<GameClient, short[]>();
            _mapInfosSent = new Dictionary<GameClient, bool>();
            OnClientIncoming += MapWrapper_OnClientIncoming;
            OnClientLeaving += MapWrapper_OnClientLeaving;
        }

        private void MapWrapper_OnClientLeaving(GameClient client)
        {
            SendMessageToAll(new GameContextRemoveElementMessage(client.Character.Id));
        }

        private void MapWrapper_OnClientIncoming(GameClient client)
        {
            RefreshCharacter(client.Character);
            foreach (var c in movementPaths)
            {
                client.SendMessage(new GameMapMovementMessage(c.Value, c.Key.Character.Id));
            }
        }

        public void AddClient(GameClient client)
        {
            lock (_mClients)
            {
                if (!_mClients.Contains(client))
                {
                    client.Character.OnLookUpdated += RefreshCharacter;
                    client.Character.OnLevelUp += Character_OnLevelUp;
                    client.OnDisconnected += Client_OnDisconnected;
                    _mClients.Add(client);
                    _mapInfosSent[client] = false;
                }
            }
        }

        public void NotifyMapInformationsSent(GameClient client)
        {
            _mapInfosSent[client] = true;
            OnClientIncoming?.Invoke(client);
        }

        private void Client_OnDisconnected(GameClient client)
        {
            RemoveClient(client);
        }

        public void RemoveClient(GameClient client)
        {
            lock (_mClients)
            {
                if (_mClients.Contains(client))
                {
                    client.Character.OnLookUpdated -= RefreshCharacter;
                    client.Character.OnLevelUp -= Character_OnLevelUp;
                    client.OnDisconnected -= Client_OnDisconnected;
                    _mClients.Remove(client);
                    _mapInfosSent.Remove(client);
                    OnClientLeaving?.Invoke(client);
                }
            }
        }

        private void Character_OnLevelUp(CharacterWrapper character)
        {
            SendMessageToAll(new CharacterLevelUpInformationMessage(character.Level, character.Name, character.Id, 0));
        }

        public void RefreshCharacter(CharacterWrapper character)
        {
            SendMessageToAll(new GameRolePlayShowActorMessage(character.ToGameRolePlayActorInformations()));
        }

        public void ForEachClients(Action<GameClient> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            lock (_mClients)
            {
                foreach (var client in _mClients)
                {
                    action(client);
                }
            }
        }

        public void SendMessageToAll(AbstractMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            ForEachClients(c => c.SendMessage(message));
        }

        public void MoveClient(GameClient client, short[] path)
        {
            movementPaths.Add(client, path);
            SendMessageToAll(new GameMapMovementMessage(path, client.Character.Id));
        }

        public void FinishClientMove(GameClient client)
        {
            movementPaths.Remove(client);
            SendMessageToAll(new GameEntityDispositionMessage(client.Character.ToEntityDispositionInformations()));
        }
    }
}
