using NUnit.Framework;
using System.Collections.Generic;

namespace ListManager.Tests
{
    public class ListManagerTests
    {
        private ListManager _listManager;
        private List<int> _list;

        [SetUp]
        public void Setup()
        {
            _listManager = new ListManager();
            _list = new List<int>();
        }

        [Test]
        public void AddElement_ShouldAddElementToList()
        {
            _listManager.AddElement(_list, 5);
            Assert.That(_list, Contains.Item(5));
        }

        [Test]
        public void RemoveElement_ShouldRemoveElementFromList()
        {
            _list.Add(5);
            _listManager.RemoveElement(_list, 5);
            Assert.That(_list, !Contains.Item(5));
        }

        [Test]
        public void GetSize_ShouldReturnCorrectSize()
        {
            _list.Add(5);
            _list.Add(10);
            var size = _listManager.GetSize(_list);
            Assert.That(size, Is.EqualTo(2));
        }
        
        [Test]
        public void AddElement_NullList_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _listManager.AddElement(null, 5));
        }

        [Test]
        public void RemoveElement_NullList_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _listManager.RemoveElement(null, 5));
        }

        [Test]
        public void GetSize_NullList_ShouldReturnZero()
        {
            var size = _listManager.GetSize(null);
            Assert.That(size, Is.EqualTo(0));
        }
    }
}
