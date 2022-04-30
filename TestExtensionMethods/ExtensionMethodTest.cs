using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using ExtensionMethods;

using Xunit;


namespace TestExtensionMethods
{
    public class ExtensionMethodTest
    {
        #region DuplicateElements Functions Tests
        [Fact]
        public void DuplicateElements_LengthOfSourceBiggerThanThanLengthOfNewSequance_ArgumentException()
        {
            //Arrange
            IEnumerable<int> OneTowThree = Enumerable.Range(1, 3);

            int LengthOfNewSequance = 0;

            //Act

            Action action = () => OneTowThree.DuplicateElements(LengthOfNewSequance);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void DuplicateElements_LengthOfNewSequanceBiggerThanLengthOfSource_NewSequanceContainDuplecateElements()
        {
            //Arrange
            var OneTowThree = Enumerable.Range(1, 3);

            int LengthOfNewSequance = 6;

            //Act
            IEnumerable<int> actual = OneTowThree
                .DuplicateElements(LengthOfNewSequance);

            IEnumerable<int> expected = new[] { 1, 2, 3, 1, 2, 3 };

            //Assert
            actual.Should()
                .Equal(expected);
        }

        #endregion

        #region Extend Function Tests
        [Fact]
        public void Extend_LengthOfSourceBiggerThanScalingLength_ArgumentException()
        {
            //Arrange
            //input:
            //{
            //    { 1, 2, 3 }
            //    { 4, 5, 6 }
            //}
            List<List<int>> source = new()
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };

            //Act
            int ScalLength = 0;
            Action action = () => source.Extend(ScalLength);

            //Assert
            action.Should().Throw<ArgumentException>();

        }
        [Fact]
        public void Extend_ModeOfScaleLengthOnLengthOfSourceDidNotEqualZero_ArgumentException()
        {
            //Arrange
            //input:
            //{
            //    { 1, 2, 3 }
            //    { 4, 5, 6 }
            //}
            List<List<int>> source = new()
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };

            //Act
            //scal length = 3 , source length = 2 
            //output :
            //{
            //  { 1, 2, 3 }
            //  { 1, 2, 3 }
            //  XXXXXXXXXXXX ?
            //}

            int ScalLength = 3;
            Action action = () => source.Extend(ScalLength);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Extend_ExtendCollection_ExtendedCollection()
        {
            //Arrange
            //input:
            //{
            //    { 1, 2, 3 }
            //    { 4, 5, 6 }
            //}
            List<List<int>> source = new()
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };

            //Act

            //output :
            //{
            //  { 1, 2, 3 }
            //  { 1, 2, 3 }
            //  { 4, 5, 6 }
            //  { 4, 5, 6 }
            //}

            int ScalLength = 4;
            IEnumerable<IEnumerable<int>> actual = source
                .Extend(ScalLength);

            IEnumerable<IEnumerable<int>> expected = new[]
            {
                new[]{1,2,3 },
                new[]{1,2,3 },
                new[]{4,5,6 },
                new[]{4,5,6 }
            };

            //Assert

            actual
                .Should()
                .BeEquivalentTo(expected);
        }

        #endregion

        #region Distribute Functions Tests

        [Fact]
        public void Distribute_LengthOfItemsToBeDistributedCollectionEqualZero_SameSourceCollection()
        {
            //Arrenge

            // input:
            //SourceCollection
            //{
            //    { 1, 2, 3 }
            //    { 4, 5, 6 }
            //}
            //ItemToBeDistributedCollection Empty

            List<List<int>> SourceCollection = new()
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };

            IEnumerable<int> ItemToBeDistributedCollection = Enumerable.Empty<int>();

            //Act

            IEnumerable<IEnumerable<int>> actual = SourceCollection
                .Distribute(ItemToBeDistributedCollection);

            IEnumerable<IEnumerable<int>> expected = SourceCollection;

            //Assert
            actual.Should()
                .BeEquivalentTo(expected);
        }

        [Fact]
        public void Distribute_LengthOfSourceCollecionEqualZero_NewCollectionOfCollectionsEachOneOfThemContatinItemFromItemsToBeDistributedCollection()
        {
            //Arrenge

            // input:
            //SourceCollection  Empty
            //ItemToBeDistributedCollection {8 , 9}

            List<List<int>> SourceCollection = Enumerable.Empty<List<int>>().ToList();


            IEnumerable<int> ItemToBeDistributedCollection = new[]{ 8, 9 };

            //Act

            IEnumerable<IEnumerable<int>> actual = SourceCollection
                .Distribute(ItemToBeDistributedCollection);

            IEnumerable<IEnumerable<int>> expected = new[]
            {
                new[] {8},
                new[] {9}
            };

            //Assert
            actual.Should()
                .BeEquivalentTo(expected);
        }
        [Fact]
        public void Distribute_LengthOfSourceCollecionNotEqualZero_NewExtendedCollectionOfCollectionsEachOneOfThemContatinOrginalElementsAndItemFromItemsToBeDistributedCollection()
        {

            //input:
            //SourceCollection
            //{
            //    { 1, 2, 3 }
            //    { 4, 5, 6 }
            //}
            //ItemToBeDistributedCollection
            //{8 , 9}
            List<List<int>> SourceCollection = new()
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 }
            };

            IEnumerable<int> ItemToBeDistributedCollection = Enumerable
                .Range(8, SourceCollection.Count); //{8 , 9}

            //Act

            //output
            //{
            //    { 1, 2, 3, 8 }
            //    { 1, 2, 3, 9 }
            //    { 4, 5, 6, 8 }
            //    { 4, 5, 6, 9 }
            //}

            IEnumerable<IEnumerable<int>> actual = SourceCollection
                .Distribute(ItemToBeDistributedCollection);

            IEnumerable<IEnumerable<int>> expected = new[]
            {
                new[]{1,2,3,8},
                new[]{1,2,3,9},
                new[]{4,5,6,8},
                new[]{4,5,6,9},
            };

            //Assert
            actual.Should()
                .BeEquivalentTo(expected);
        }

        #endregion

    }
}