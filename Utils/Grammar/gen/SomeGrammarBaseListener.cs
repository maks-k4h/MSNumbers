//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/makskonevych/Documents/C#/Labs/MSNumbers/Utils/Grammar/SomeGrammar.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ISomeGrammarListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class SomeGrammarBaseListener : ISomeGrammarListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLine([NotNull] SomeGrammarParser.LineContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLine([NotNull] SomeGrammarParser.LineContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.sum"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSum([NotNull] SomeGrammarParser.SumContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.sum"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSum([NotNull] SomeGrammarParser.SumContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.addend"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAddend([NotNull] SomeGrammarParser.AddendContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.addend"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAddend([NotNull] SomeGrammarParser.AddendContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.multiplier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplier([NotNull] SomeGrammarParser.MultiplierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.multiplier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplier([NotNull] SomeGrammarParser.MultiplierContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.atomic"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAtomic([NotNull] SomeGrammarParser.AtomicContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.atomic"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAtomic([NotNull] SomeGrammarParser.AtomicContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.enclosed_sum"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterEnclosed_sum([NotNull] SomeGrammarParser.Enclosed_sumContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.enclosed_sum"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitEnclosed_sum([NotNull] SomeGrammarParser.Enclosed_sumContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.inc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInc([NotNull] SomeGrammarParser.IncContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.inc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInc([NotNull] SomeGrammarParser.IncContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.dec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDec([NotNull] SomeGrammarParser.DecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.dec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDec([NotNull] SomeGrammarParser.DecContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.max"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMax([NotNull] SomeGrammarParser.MaxContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.max"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMax([NotNull] SomeGrammarParser.MaxContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.min"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMin([NotNull] SomeGrammarParser.MinContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.min"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMin([NotNull] SomeGrammarParser.MinContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.cell"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCell([NotNull] SomeGrammarParser.CellContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.cell"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCell([NotNull] SomeGrammarParser.CellContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="SomeGrammarParser.float"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFloat([NotNull] SomeGrammarParser.FloatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SomeGrammarParser.float"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFloat([NotNull] SomeGrammarParser.FloatContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
