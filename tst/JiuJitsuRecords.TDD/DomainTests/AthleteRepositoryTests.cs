using FluentAssertions;
using JiuJitsuRecords.Domain.Entities;
using JiuJitsuRecords.Domain.Repositories;
using JiuJitsuRecords.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JiuJitsuRecords.TDD.DomainTests
{
    public class AthleteRepositoryTests
    {
        private IEnumerable<Jiujiteiro> CreateFakeData()
        {
            yield return new Jiujiteiro(1,
                                        "Mica",
                                        "Micael Ferreira",
                                        "Galvão",
                                        new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                        EstiloPreferencial.Any,
                                        "Micael Galvão, também conhecido como Mica (Manaus, 8 de outubro de 2003), é um lutador profissional de Jiu-jitsu campeão mundial em sua categoria e absoluto. Mica é filho e faixa preta do mestre Melqui Galvão, e compete pela academia Fight Sports.",
                                        new List<int> { 1 });
            yield return new Jiujiteiro(2,
                                        "N/A",
                                        "Kade",
                                        "Ruotolo",
                                        new DateTimeOffset(2003, 10, 8, 0, 0, 0, TimeSpan.Zero),
                                        EstiloPreferencial.Pass,
                                        "Kade Ruotolo is a Brazilian jiujitsu submission grappling athlete. A competitor with his brother Tye since the age of 3, Ruotolo is a two-time IBJJF World champion, Pan Am and European Open champion in brown belt. Promoted to black belt in December 2021, Ruotolo won the 2022 ADCC World Championship in the 77kg division, becoming at age 19 the youngest-ever ADCC Submission Fighting World champion",
                                        new List<int>());
        }

        [Fact]
        public void ShouldAthleteRepositoryGetAthletesMethodReturnAListOfTwoAthletes()
        {
            // Arrange
            var expectedResult = CreateFakeData();

            IAthleteRepository athleteRepository = new AthleteRepository();

            // Act
            var actualResult = athleteRepository.GetAthletes()
                                                .GetAwaiter()
                                                .GetResult();

            // Assert
            actualResult.Should()
                        .NotBeNullOrEmpty().And
                        .HaveCount(2).And
                        .Contain(a => expectedResult.Any(e => e.Id == a.Id
                                                           && e.Apelido == a.Apelido
                                                           && e.EstiloPreferencial == a.EstiloPreferencial
                                                           && e.Nascimento == a.Nascimento
                                                           && e.Descricao == a.Descricao
                                                           && e.PosicaoIds.All(x => a.PosicaoIds.Any(y => y == x))));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ShouldAthleteRepositoryGetAthleteByIdMethodReturnsSpecificAthlete(int athleteId)
        {
            // Arrange
            IAthleteRepository athleteRepository = new AthleteRepository();

            // Act
            var actualAthlete = athleteRepository.GetAthleteById(athleteId)
                                                 .GetAwaiter()
                                                 .GetResult();

            // Assert
            actualAthlete.Should()
                         .NotBeNull().And
                         .Match<Jiujiteiro?>(x => x!.Id == athleteId);
        }

        [Theory]
        [InlineData(500)]
        [InlineData(404)]
        public void ShouldAthleteRepositoryGetAthleteByIdMethodReturnsNullForUnidentifiedId(int unexistentAthleteId)
        {
            // Arrange
            IAthleteRepository athleteRepository = new AthleteRepository();

            // Act
            var actualAthlete = athleteRepository.GetAthleteById(unexistentAthleteId)
                                                 .GetAwaiter()
                                                 .GetResult();

            // Assert
            actualAthlete.Should()
                         .BeNull();
        }

        [Fact]
        public void ShouldRepositoryMethodInsertAthleteStoreTheSpecifiedAthlete()
        {
            // Arrange
            var athleteId = 8;
            var expectedAthlete = new Jiujiteiro(athleteId, "Apelido", "Nome", "Sobrenome", new DateTimeOffset(2022, 8, 31, 0, 0, 0, TimeSpan.FromHours(-1)), EstiloPreferencial.Guard, "Descrição", new List<int>());

            IAthleteRepository athleteRepository = new AthleteRepository();

            // Act
            athleteRepository.InsertAthlete(expectedAthlete)
                             .GetAwaiter()
                             .GetResult();
            var retrievedAthlete = athleteRepository.GetAthleteById(athleteId)
                                                    .GetAwaiter()
                                                    .GetResult();

            // Assert
            retrievedAthlete.Should()
                            .NotBeNull().And
                            .Be(expectedAthlete);
        }
    }
}