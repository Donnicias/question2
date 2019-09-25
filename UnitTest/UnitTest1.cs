using EmployeesHierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [Fact]
        public void TestEmployees()
        {
            var lines = File.ReadAllLines("../../../test.txt");
            Employees employees = new Employees(lines);
            Assert.Equals(3300, employees.SalaryBudget("Employee1"));
            Assert.Equals(1000, employees.SalaryBudget("Employee2"));

        }

        [Fact]
        public void TestDoubleLink()
        {
            var lines = File.ReadAllLines("../../../test1.txt");
            Employees employees = new Employees(lines);
            Assert.Equals(3300, employees.SalaryBudget("Employee1"));
            Assert.Equals(1000, employees.SalaryBudget("Employee2"));

        }

        [Fact]
        public void Test2()
        {
            var lines = File.ReadAllLines("../../../test2.txt");
            Employees employees = new Employees(lines);
            Assert.Equals(3800, employees.SalaryBudget("Employee1"));
            Assert.Equals(1800, employees.SalaryBudget("Employee2"));
            Assert.Equals(500, employees.SalaryBudget("Employee3"));

        }

        //test invalid salary value for employee 6
        [Fact]
        public void Test3()
        {
            var lines = File.ReadAllLines("../../../test3.txt");
            Employees employees = new Employees(lines);
            Assert.Equals(3300, employees.SalaryBudget("Employee1"));
            Assert.Equals(1300, employees.SalaryBudget("Employee2"));
            Assert.Equals(500, employees.SalaryBudget("Employee3"));
            Assert.Equals(0, employees.SalaryBudget("Employee6"));

        }
    }

    public static class GraphsDirectedSparseGraphTest
    {
        [Fact]
        public static void DoTest()
        {
            var graph = new DirectedSparseGraph<Employee>();

            var employeeA = new Employee("a", "", 10);
            var employeeB = new Employee("b", "a", 10);
            var employeeC = new Employee("c", "a", 10);
            var employeeD = new Employee("d", "a", 10);
            var employeeE = new Employee("e", "b", 10);

            var verticesSet1 = new Employee[] { employeeA, employeeB, employeeC, employeeD, employeeE };

            graph.AddVertices(verticesSet1);

            graph.AddEdge(employeeA, employeeB);
            graph.AddEdge(employeeA, employeeC);
            graph.AddEdge(employeeA, employeeD);
            graph.AddEdge(employeeB, employeeE);

            var allEdges = graph.Edges.ToList();

            Assert.IsTrue(graph.VerticesCount == 5, "Wrong vertices count.");
            Assert.IsTrue(graph.EdgesCount == 4, "Wrong edges count.");
            Assert.IsTrue(graph.EdgesCount == allEdges.Count, "Wrong edges count.");

            Assert.IsTrue(graph.OutgoingEdges(employeeA).ToList().Count == 3, "Wrong outgoing edges from 'a'.");
            Assert.IsTrue(graph.OutgoingEdges(employeeB).ToList().Count == 1, "Wrong outgoing edges from 'b'.");
            Assert.IsTrue(graph.OutgoingEdges(employeeC).ToList().Count == 0, "Wrong outgoing edges from 'c'.");
            Assert.IsTrue(graph.OutgoingEdges(employeeD).ToList().Count == 0, "Wrong outgoing edges from 'd'.");
            Assert.IsTrue(graph.OutgoingEdges(employeeE).ToList().Count == 0, "Wrong outgoing edges from 'e'.");


            Assert.IsTrue(graph.IncomingEdges(employeeA).ToList().Count == 0, "Wrong incoming edges from 'a'.");
            Assert.IsTrue(graph.IncomingEdges(employeeB).ToList().Count == 1, "Wrong incoming edges from 'b'.");
            Assert.IsTrue(graph.IncomingEdges(employeeC).ToList().Count == 1, "Wrong incoming edges from 'c'.");
            Assert.IsTrue(graph.IncomingEdges(employeeD).ToList().Count == 1, "Wrong incoming edges from 'd'.");
            Assert.IsTrue(graph.IncomingEdges(employeeE).ToList().Count == 1, "Wrong incoming edges from 'e'.");


            // DFS from A
            // Walk the graph using DFS from A:
            var dfsWalk = graph.DepthFirstWalk(employeeA);
            // output: (s) (a) (x) (z) (d) (c) (f) (v)
            // foreach (var node in dfsWalk)
            // {
            //     Console.Write(String.Format("({0})", node));
            // }

            // DFS from F
            // Walk the graph using DFS from F:
            //dfsWalk = graph.DepthFirstWalk(employeeB);
            // output: (s) (a) (x) (z) (d) (c) (f) (v)
            foreach (var node in dfsWalk)
            {
                Console.Write(String.Format("({0})", node.Id));
            }


            /********************************************************************/


            graph.Clear();

        }

    }
}
