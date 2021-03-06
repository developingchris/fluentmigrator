using System;
using System.Data;
using FluentMigrator.Expressions;
using FluentMigrator.Infrastructure;
using FluentMigrator.Tests.Helpers;
using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit.Expressions
{
	[TestFixture]
	public class CreateColumnExpressionTests
	{
		[Test]
		public void ErrorIsReturnedWhenOldNameIsNull()
		{
			var expression = new CreateColumnExpression { TableName = null };
			var errors = ValidationHelper.CollectErrors(expression);
			errors.ShouldContain(ErrorMessages.TableNameCannotBeNullOrEmpty);
		}

		[Test]
		public void ErrorIsReturnedWhenOldNameIsEmptyString()
		{
			var expression = new CreateColumnExpression { TableName = String.Empty };
			var errors = ValidationHelper.CollectErrors(expression);
			errors.ShouldContain(ErrorMessages.TableNameCannotBeNullOrEmpty);
		}

		[Test]
		public void ErrorIsNotReturnedWhenOldNameIsNotNullEmptyString()
		{
			var expression = new CreateColumnExpression { TableName = "Bacon" };
			var errors = ValidationHelper.CollectErrors(expression);
			errors.ShouldNotContain(ErrorMessages.TableNameCannotBeNullOrEmpty);
		}

		[Test]
		public void ReverseReturnsDeleteColumnExpression()
		{
			var expression = new CreateColumnExpression { TableName = "Bacon", Column = { Name = "BaconId" } };
			var reverse = expression.Reverse();
			reverse.ShouldBeOfType<DeleteColumnExpression>();
		}

		[Test]
		public void ReverseSetsTableNameAndColumnNameOnGeneratedExpression()
		{
			var expression = new CreateColumnExpression { TableName = "Bacon", Column = { Name = "BaconId" } };
			var reverse = expression.Reverse() as DeleteColumnExpression;
			reverse.TableName.ShouldBe("Bacon");
			reverse.ColumnName.ShouldBe("BaconId");
		}

		[Test]
		public void ToStringIsDescriptive()
		{
			var expression = new CreateColumnExpression { TableName = "Bacon", Column = { Name = "BaconId", Type = DbType.Int32 } };
			expression.ToString().ShouldBe("CreateColumn Bacon BaconId Int32");	
		}
	}
}