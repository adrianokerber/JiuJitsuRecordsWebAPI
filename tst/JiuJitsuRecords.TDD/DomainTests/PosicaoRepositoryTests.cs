using FluentAssertions;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Infraestructure.Repositories;
using System.Collections.Generic;
using Xunit;

namespace JiuJitsuRecords.TDD.DomainTests
{
    public class PosicaoRepositoryTests
    {
        [Fact]
        public void ShouldGetPositionsMethodReturnAListWithTheTwoFakeElementsRegisteredUponCreation()
        {
            // Arrange
            var expectedResult = new List<Posicao> {
                new Posicao(0, "Armlock", "Se caracteriza por ser uma alavanca de braço ao travar o braço entre as pernas e puxar para o rosto"),
                new Posicao(1, "Triângulo", "Se caracteriza por criar a forma de um triângulo por entre as pernas ao cruzar o joelho sobre um dos pés")
            };

            IPositionRepository posicaoRepository = new PositionRepository();

            // Act
            var actualResult = posicaoRepository.GetPositions()
                                                .GetAwaiter()
                                                .GetResult();

            // Assert
            actualResult.Should()
                        .NotBeNullOrEmpty().And
                        .HaveCount(2).And
                        .Contain(expectedResult);
        }

        [Theory]
        [InlineData(new int[2] { 0, 1 })]
        public void ShouldGetPositionsMethodReturnTheElementsByTheProvidedIds(int[] expectedIds)
        {
            // Arrange
            IPositionRepository posicaoRepository = new PositionRepository();

            // Act
            var actualResult = posicaoRepository.GetPositionsByIds(expectedIds)
                                                .GetAwaiter()
                                                .GetResult();

            // Assert
            actualResult.Should()
                        .NotBeNullOrEmpty().And
                        .HaveSameCount(expectedIds).And
                        .Equal(expectedIds, (e, a) => e.Id == a);
        }

        [Theory]
        [InlineData("Armlock")]
        [InlineData("Triângulo")]
        public void ShouldGetPositionByName(string posicaoName)
        {
            // Arrange
            IPositionRepository posicaoRepository = new PositionRepository();

            // Act
            var actualResult = posicaoRepository.GetPositionByName(posicaoName)
                                                .GetAwaiter()
                                                .GetResult();

            // Assert
            actualResult.Should()
                        .NotBeNull().And
                        .Match<Posicao>(x => x.Nome == posicaoName);
        }

        [Theory]
        [InlineData(1)]
        public void ShouldGetPositionByIdMethodReturnsSpecificPosition(int posicaoId)
        {
            // Arrange
            IPositionRepository posicaoRepository = new PositionRepository();

            // Act
            var actualPosition = posicaoRepository.GetPositionById(posicaoId)
                                                  .GetAwaiter()
                                                  .GetResult();

            // Assert
            actualPosition.Should()
                          .NotBeNull().And
                          .Match<Posicao?>(x => x!.Id == posicaoId);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(404)]
        public void ShouldGetPositionByIdMethodReturnsNullForUnidentifiedId(int unexistentPositionId)
        {
            // Arrange
            IPositionRepository posicaoRepository = new PositionRepository();

            // Act
            var actualPosition = posicaoRepository.GetPositionById(unexistentPositionId)
                                                  .GetAwaiter()
                                                  .GetResult();

            // Assert
            actualPosition.Should()
                          .BeNull();
        }

        [Theory]
        [InlineData(8, "Nome", "Descrição")]
        [InlineData(9, "Nome", "Descrição")]
        [InlineData(10, "Nome", "Descrição")]
        public void ShouldRepositoryMethodInsertPositionStoreTheObjectPositionWithTheSpecifiedId(int posicaoId, string posicaoName, string posicaoDescription)
        {
            // Arrange
            var expectedPosition = new Posicao(posicaoId, posicaoName, posicaoDescription);

            IPositionRepository positionRepository = new PositionRepository();

            // Act
            positionRepository.InsertPosition(expectedPosition)
                              .GetAwaiter()
                              .GetResult();
            var retrievedPosition = positionRepository.GetPositionById(posicaoId)
                                                      .GetAwaiter()
                                                      .GetResult();

            // Assert
            retrievedPosition.Should()
                             .NotBeNull().And
                             .Be(expectedPosition);
        }

        [Theory]
        [InlineData(-1, "Nome", "Descrição")]
        [InlineData(-10, "Nome", "Descrição")]
        [InlineData(-987654321, "Nome", "Descrição")]
        public void ShouldRepositoryMethodInsertPositionReceivingAnObjectWithAnInvalidIdReplaceThisByAValidOneAndStoreTheObject(int posicaoId, string posicaoName, string posicaoDescription)
        {
            // Arrange
            var expectedPosition = new Posicao(posicaoId, posicaoName, posicaoDescription);

            IPositionRepository positionRepository = new PositionRepository();

            // Act
            var registeredPosition = positionRepository.InsertPosition(expectedPosition)
                                                       .GetAwaiter()
                                                       .GetResult();

            // Assert
            registeredPosition.Should()
                              .NotBeNull().And
                              .Match<Posicao>(x =>
                                  x.Id != posicaoId
                               && x.Nome == posicaoName
                               && x.Descricao == posicaoDescription
                              );
        }
    }
}
