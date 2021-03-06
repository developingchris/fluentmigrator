﻿using System;
using System.Collections.Generic;
using FluentMigrator.Builders.Create.ForeignKey;
using FluentMigrator.Expressions;
using FluentMigrator.Model;
using Moq;
using NUnit.Framework;

namespace FluentMigrator.Tests.Unit.Builders.Create
{
	[TestFixture]
	public class CreateForeignKeyExpressionBuilderTests
	{
		[Test]
		public void CallingFromTableSetsForeignTableName()
		{
			var foreignKeyMock = new Mock<ForeignKeyDefinition>();
			foreignKeyMock.SetupSet(f => f.ForeignTable = "Bacon").AtMostOnce();

			var expressionMock = new Mock<CreateForeignKeyExpression>();
			expressionMock.SetupGet(e => e.ForeignKey).Returns(foreignKeyMock.Object).AtMostOnce();

			var builder = new CreateForeignKeyExpressionBuilder(expressionMock.Object);
			builder.FromTable("Bacon");

			foreignKeyMock.VerifyAll();
			expressionMock.VerifyAll();
		}

		[Test]
		public void CallingToTableSetsPrimaryTableName()
		{
			var foreignKeyMock = new Mock<ForeignKeyDefinition>();
			foreignKeyMock.SetupSet(f => f.PrimaryTable = "Bacon").AtMostOnce();

			var expressionMock = new Mock<CreateForeignKeyExpression>();
			expressionMock.SetupGet(e => e.ForeignKey).Returns(foreignKeyMock.Object).AtMostOnce();

			var builder = new CreateForeignKeyExpressionBuilder(expressionMock.Object);
			builder.ToTable("Bacon");

			foreignKeyMock.VerifyAll();
			expressionMock.VerifyAll();
		}

		[Test]
		public void CallingForeignColumnAddsColumnNameToForeignColumnCollection()
		{
			var collectionMock = new Mock<IList<string>>();
			collectionMock.Setup(x => x.Add("BaconId")).AtMostOnce();

			var foreignKeyMock = new Mock<ForeignKeyDefinition>();
			foreignKeyMock.SetupGet(f => f.ForeignColumns).Returns(collectionMock.Object).AtMostOnce();

			var expressionMock = new Mock<CreateForeignKeyExpression>();
			expressionMock.SetupGet(e => e.ForeignKey).Returns(foreignKeyMock.Object).AtMostOnce();

			var builder = new CreateForeignKeyExpressionBuilder(expressionMock.Object);
			builder.ForeignColumn("BaconId");

			collectionMock.VerifyAll();
			foreignKeyMock.VerifyAll();
			expressionMock.VerifyAll();
		}

		[Test]
		public void CallingForeignColumnsAddsColumnNamesToForeignColumnCollection()
		{
			var collectionMock = new Mock<IList<string>>();
			collectionMock.Setup(x => x.Add("BaconId")).AtMostOnce();
			collectionMock.Setup(x => x.Add("EggsId")).AtMostOnce();

			var foreignKeyMock = new Mock<ForeignKeyDefinition>();
			foreignKeyMock.SetupGet(f => f.ForeignColumns).Returns(collectionMock.Object).AtMost(2);

			var expressionMock = new Mock<CreateForeignKeyExpression>();
			expressionMock.SetupGet(e => e.ForeignKey).Returns(foreignKeyMock.Object).AtMost(2);

			var builder = new CreateForeignKeyExpressionBuilder(expressionMock.Object);
			builder.ForeignColumns("BaconId", "EggsId");

			collectionMock.VerifyAll();
			foreignKeyMock.VerifyAll();
			expressionMock.VerifyAll();
		}

		[Test]
		public void CallingPrimaryColumnAddsColumnNameToPrimaryColumnCollection()
		{
			var collectionMock = new Mock<IList<string>>();
			collectionMock.Setup(x => x.Add("BaconId")).AtMostOnce();

			var foreignKeyMock = new Mock<ForeignKeyDefinition>();
			foreignKeyMock.SetupGet(f => f.PrimaryColumns).Returns(collectionMock.Object).AtMostOnce();

			var expressionMock = new Mock<CreateForeignKeyExpression>();
			expressionMock.SetupGet(e => e.ForeignKey).Returns(foreignKeyMock.Object).AtMostOnce();

			var builder = new CreateForeignKeyExpressionBuilder(expressionMock.Object);
			builder.PrimaryColumn("BaconId");

			collectionMock.VerifyAll();
			foreignKeyMock.VerifyAll();
			expressionMock.VerifyAll();
		}

		[Test]
		public void CallingPrimaryColumnsAddsColumnNamesToForeignColumnCollection()
		{
			var collectionMock = new Mock<IList<string>>();
			collectionMock.Setup(x => x.Add("BaconId")).AtMostOnce();
			collectionMock.Setup(x => x.Add("EggsId")).AtMostOnce();

			var foreignKeyMock = new Mock<ForeignKeyDefinition>();
			foreignKeyMock.SetupGet(f => f.PrimaryColumns).Returns(collectionMock.Object).AtMost(2);

			var expressionMock = new Mock<CreateForeignKeyExpression>();
			expressionMock.SetupGet(e => e.ForeignKey).Returns(foreignKeyMock.Object).AtMost(2);

			var builder = new CreateForeignKeyExpressionBuilder(expressionMock.Object);
			builder.PrimaryColumns("BaconId", "EggsId");

			collectionMock.VerifyAll();
			foreignKeyMock.VerifyAll();
			expressionMock.VerifyAll();
		}
	}
}