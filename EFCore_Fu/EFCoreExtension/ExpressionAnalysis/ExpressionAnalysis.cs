using EFCore_Fu.EFCoreExtension.ExpressionTypeExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Fu.EFCoreExtension.ExpressionAnalysis
{
    internal class ExpressionAnalysis : ExpressionVisitor
    {
        private readonly Stack<String> _whereString = new();

        public string GetWhereString => string.Join(" ", _whereString);
        [return: NotNullIfNotNull("node")]
        public override Expression? Visit(Expression? node)
        {
            return base.Visit(node);
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            this._whereString.Push(")");
            this.Visit(node.Right);
            this._whereString.Push(node.NodeType.ToSqlOperator().ToString());
            this.Visit(node.Left);
            this._whereString.Push("(");
            return node;
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value is not null)
            {
                if (node.Type == typeof(string))
                {
                    this._whereString.Push("'" + node.Value.ToString()! + "'");
                }
                if (node.Type == typeof(int))
                {
                    this._whereString.Push(node.Value.ToString()!);
                }
                if (node.Type == typeof(bool))
                {

                }
                if (node.Type == typeof(DateTime))
                {

                }

            }
            return base.VisitConstant(node);
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return base.VisitMethodCall(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            this._whereString.Push(node.Member.Name);
            return base.VisitMember(node);
        }
    }
}
