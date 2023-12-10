using System.Collections.Generic;
using Ar;
using ARCarols.Scripts.Character.Config;
using ARCarols.Scripts.Character.Provider;
using Project.Scripts.Models.Interfaces;
using UnityEngine;

namespace ARCarols.Scripts.Models
{
    public class KolyadaActionModel : IModel
    {
        private CharacterTextConfig _kolyadaSongs;

        private ArManager _arManager;

        private List<CharacterTextProvider> _songs = new();

        public KolyadaActionModel(CharacterTextConfig kolyadaSongs, ArManager arManager)
        {
            _kolyadaSongs = kolyadaSongs;

            _arManager = arManager;
        }

        public void SetCharacterText()
        {
            var character = _arManager.GetCurrentCharacter();
            
            if (character.IsTextWriting)
            {
                character.SkipAnimation();
                
                return;
            }
            
            if (_songs.Count == 0)
            {
                RefreshSongs();
            }
            
            var currentSongs = _songs[Random.Range(0, _songs.Count)];
            
            character.SetText(currentSongs.Text, currentSongs.AudioClip);

            _songs.Remove(currentSongs);
        }
        

        private void RefreshSongs()
        {
            _songs.Clear();


            foreach (var item in _kolyadaSongs.CharacterTextProviders)
            {
                var characterTextProvider = new CharacterTextProvider
                {
                    Text = item.Text,
                    AudioClip = item.AudioClip
                };

                _songs.Add(characterTextProvider);
            }
        }
    }
}