using DreamAPI.Data;
using DreamAPI.Models.Character;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamAPI.Services
{
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                { 
                    Name = model.Name,
                    Description = model.Description,
                    Relationship = model.Relationship
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Characters
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CharacterListItem
                                {
                                    Name = e.Name,
                                    Description = e.Description,
                                    Relationship = e.Relationship
                                }
                           );

                return query.ToArray();
            }
        }
    }
}
