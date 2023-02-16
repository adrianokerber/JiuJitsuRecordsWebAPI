using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Infraestructure.Documents;

namespace JiuJitsuRecords.Infraestructure.Mappers
{
    public static class JiujiteiroMapper
    {
        public static JiujiteiroDocument ToDocument(this Jiujiteiro entity, int entityId)
            => new JiujiteiroDocument(entityId,
                                      entity.Apelido,
                                      entity.Nome,
                                      entity.Sobrenome,
                                      entity.Nascimento,
                                      entity.EstiloPreferencial,
                                      entity.Descricao,
                                      entity.PosicaoIds);

        public static IEnumerable<Jiujiteiro> ToDomainList(this IEnumerable<JiujiteiroDocument> documents)
        {
            foreach (var document in documents)
            {
                yield return document.ToDomain();
            }
        }

        public static Jiujiteiro ToDomain(this JiujiteiroDocument document)
            => new Jiujiteiro(document.Apelido,
                              document.Nome,
                              document.Sobrenome,
                              document.Nascimento,
                              document.EstiloPreferencial,
                              document.Descricao,
                              document.PosicaoIds,
                              document.Id);
    }
}
