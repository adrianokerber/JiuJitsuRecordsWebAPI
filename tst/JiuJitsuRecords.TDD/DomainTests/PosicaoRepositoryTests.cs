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
        public void ShouldGetPositionsMethodReturnAListWithTwoElements()
        {
            // Arrange
            var expectedResult = new List<Posicao> {
                new Posicao(1, "Armlock", "Se caracteriza por ser uma alavanca de braço ao travar o braço entre as pernas e puxar para o rosto"),
                new Posicao(2, "Triângulo", "Se caracteriza por criar a forma de um triângulo por entre as pernas ao cruzar o joelho sobre um dos pés")
            };

            IPositionRepository posicaoRepository = new PosicaoRepository();

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
        [InlineData(1)]
        public void ShouldGetPositionByIdMethodReturnsSpecificPosition(int posicaoId)
        {
            // Arrange
            IPositionRepository posicaoRepository = new PosicaoRepository();

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
            IPositionRepository posicaoRepository = new PosicaoRepository();

            // Act
            var actualPosition = posicaoRepository.GetPositionById(unexistentPositionId)
                                                  .GetAwaiter()
                                                  .GetResult();

            // Assert
            actualPosition.Should()
                       .BeNull();
        }

        [Fact]
        public void ShouldRepositoryMethodInsertPositionStoreTheSpecifiedPosition()
        {
            // Arrange
            var posicaoId = 8;
            var expectedPosition = new Posicao(posicaoId, "Nome", "Descricao");

            IPositionRepository posicaoRepository = new PosicaoRepository();

            // Act
            posicaoRepository.InsertPosition(expectedPosition)
                             .GetAwaiter()
                             .GetResult();
            var retrievedPosition = posicaoRepository.GetPositionById(posicaoId)
                                                  .GetAwaiter()
                                                  .GetResult();

            // Assert
            retrievedPosition.Should()
                          .NotBeNull().And
                          .Be(expectedPosition);
        }
    }
}
