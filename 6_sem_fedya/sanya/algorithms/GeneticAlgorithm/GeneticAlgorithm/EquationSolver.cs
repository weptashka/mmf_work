using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using GeneticAlgorithm.utils;

namespace GeneticAlgorithm
{
    public class EquationSolver
    {
        private const int MinValue = -100;
        private const int MaxValue = 100;
        private const int PopulationCount = 1000;
        private const double SelectionProbabilityBound = 0.6;
        private const double CrossbreedingProbability = 0.5;
        private const double MutationProbability = 0.2;

        private readonly int[] Powers;
        private readonly int Result;

        public EquationSolver(int[] powers, int result)
        {
            Powers = powers;
            Result = result;
        }
        
        public (Individual, int) Solve()
        {
            List<Individual> individuals = InitializePopulation();
            Individual solution = GetSolution(individuals);

            int iterations = 1;
            while (solution == null)
            {
                individuals = Substitution(individuals);
                solution = GetSolution(individuals);
                iterations += 1;
            }

            return (solution, iterations);
        }
        
        private List<Individual> Select(List<Individual> individuals)
        {
            return individuals.Where(individual => Probability.GenerateProbability() > SelectionProbabilityBound).ToList();
        }
        
        private List<Individual> Crossbreeding(List<Individual> individuals)
        {
            var children = new List<Individual>();

            for (int i = 0; i < individuals.Count - 1; i += 2)
            {
                var parent1 = individuals.ElementAt(i);
                var parent2 = individuals.ElementAt(i + 1);
                children.Add(new Individual(
                    Probability.ComeTrue(CrossbreedingProbability) ? parent1.X : parent2.X,
                    Probability.ComeTrue(CrossbreedingProbability) ? parent1.Y : parent2.Y,
                    Probability.ComeTrue(CrossbreedingProbability) ? parent1.Z : parent2.Z,
                    Probability.ComeTrue(CrossbreedingProbability) ? parent1.U : parent2.U,
                    Probability.ComeTrue(CrossbreedingProbability) ? parent1.W : parent2.W
                ));
            }

            return children;
        }

        private List<Individual> Mutation(List<Individual> individuals)
        {
            return individuals
                .Select(individual => new Individual(
                    Probability.ComeTrue(MutationProbability) ? Individual.GenerateGenome(MinValue, MaxValue) : individual.X,
                    Probability.ComeTrue(MutationProbability) ? Individual.GenerateGenome(MinValue, MaxValue) : individual.Y,
                    Probability.ComeTrue(MutationProbability) ? Individual.GenerateGenome(MinValue, MaxValue) : individual.Z,
                    Probability.ComeTrue(MutationProbability) ? Individual.GenerateGenome(MinValue, MaxValue) : individual.U,
                    Probability.ComeTrue(MutationProbability) ? Individual.GenerateGenome(MinValue, MaxValue) : individual.W
                     ))
                .ToList();
        }
        
        private List<Individual> Substitution(List<Individual> prevIndividuals)
        {
            List<Individual> nextIndividuals = Mutation(Crossbreeding(Select(prevIndividuals)));
            List<Individual> sortedPrevIndividuals = prevIndividuals.OrderBy(GetSolutionError).ToList();
            
            sortedPrevIndividuals.RemoveRange(prevIndividuals.Count - 1 - nextIndividuals.Count, nextIndividuals.Count);
            sortedPrevIndividuals.AddRange(nextIndividuals);

            return sortedPrevIndividuals;
        }
        
        private List<Individual> InitializePopulation() => Enumerable.Range(0, PopulationCount)
            .Select(_ => Individual.Generate(MinValue, MaxValue))
            .ToList();
        
        private Individual? GetSolution(List<Individual> individuals)
        {
            Individual strongestIndividual = individuals.OrderBy(GetSolutionError).ToList().First();

            if (GetSolutionError(strongestIndividual) > 0)
            {
                Console.WriteLine($"X = {strongestIndividual.X}, Y = {strongestIndividual.Y}, Z = {strongestIndividual.Z}, U = {strongestIndividual.U}, W = {strongestIndividual.W}");
                return null;
            }

            return strongestIndividual;
        }

        public long GetSolutionError(Individual individual) => Math.Abs(
            MathUtil.Pow(individual.X, Powers[0]) * MathUtil.Pow(individual.Y, Powers[1]) * MathUtil.Pow(individual.Z, Powers[2]) *
            MathUtil.Pow(individual.U, Powers[3]) * MathUtil.Pow(individual.W, Powers[4]) +
            MathUtil.Pow(individual.X, Powers[5]) * MathUtil.Pow(individual.Y, Powers[6]) * MathUtil.Pow(individual.Z, Powers[7]) *
            MathUtil.Pow(individual.U, Powers[8]) * MathUtil.Pow(individual.W, Powers[9]) +
            MathUtil.Pow(individual.X, Powers[10]) * MathUtil.Pow(individual.Y, Powers[11]) *
            MathUtil.Pow(individual.Z, Powers[12]) * MathUtil.Pow(individual.U, Powers[13]) *
            MathUtil.Pow(individual.W, Powers[14]) +
            MathUtil.Pow(individual.X, Powers[15]) * MathUtil.Pow(individual.Y, Powers[16]) *
            MathUtil.Pow(individual.Z, Powers[17]) * MathUtil.Pow(individual.U, Powers[18]) *
            MathUtil.Pow(individual.W, Powers[19]) +
            MathUtil.Pow(individual.X, Powers[20]) * MathUtil.Pow(individual.Y, Powers[21]) *
            MathUtil.Pow(individual.Z, Powers[22]) * MathUtil.Pow(individual.U, Powers[23]) *
            MathUtil.Pow(individual.W, Powers[24]) - Result);
    }
}