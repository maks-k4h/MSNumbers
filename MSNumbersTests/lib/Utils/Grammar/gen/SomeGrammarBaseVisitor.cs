//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/makskonevych/Documents/C#/Labs/MSNumbers/MSNumbers/Utils/Grammar/SomeGrammar.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ISomeGrammarVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class SomeGrammarBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, ISomeGrammarVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.line"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLine([NotNull] SomeGrammarParser.LineContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.sum"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSum([NotNull] SomeGrammarParser.SumContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.addend"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAddend([NotNull] SomeGrammarParser.AddendContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.multiplier"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMultiplier([NotNull] SomeGrammarParser.MultiplierContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.atomic"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAtomic([NotNull] SomeGrammarParser.AtomicContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.enclosed_sum"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitEnclosed_sum([NotNull] SomeGrammarParser.Enclosed_sumContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.inc"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInc([NotNull] SomeGrammarParser.IncContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.dec"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDec([NotNull] SomeGrammarParser.DecContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.max"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMax([NotNull] SomeGrammarParser.MaxContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.min"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMin([NotNull] SomeGrammarParser.MinContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.cell"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCell([NotNull] SomeGrammarParser.CellContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="SomeGrammarParser.float"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFloat([NotNull] SomeGrammarParser.FloatContext context) { return VisitChildren(context); }
}
