//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/makskonevych/Documents/C#/test/ConsoleApp1/ConsoleApp1/Grammar/SomeGrammar.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public partial class SomeGrammarParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, WS=14, LETTER=15, INT=16;
	public const int
		RULE_line = 0, RULE_sum = 1, RULE_addend = 2, RULE_multiplier = 3, RULE_atomic = 4, 
		RULE_enclosed_sum = 5, RULE_inc = 6, RULE_dec = 7, RULE_max = 8, RULE_min = 9, 
		RULE_cell = 10, RULE_float = 11;
	public static readonly string[] ruleNames = {
		"line", "sum", "addend", "multiplier", "atomic", "enclosed_sum", "inc", 
		"dec", "max", "min", "cell", "float"
	};

	private static readonly string[] _LiteralNames = {
		null, "'+'", "'-'", "'*'", "'/'", "'^'", "'('", "')'", "'inc('", "'dec('", 
		"'max('", "','", "'min('", "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, "WS", "LETTER", "INT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "SomeGrammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static SomeGrammarParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SomeGrammarParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SomeGrammarParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class LineContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum() {
			return GetRuleContext<SumContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(SomeGrammarParser.Eof, 0); }
		public LineContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_line; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLine(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LineContext line() {
		LineContext _localctx = new LineContext(Context, State);
		EnterRule(_localctx, 0, RULE_line);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 24;
			sum();
			State = 25;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SumContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public AddendContext addend() {
			return GetRuleContext<AddendContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum() {
			return GetRuleContext<SumContext>(0);
		}
		public SumContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_sum; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterSum(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitSum(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSum(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SumContext sum() {
		SumContext _localctx = new SumContext(Context, State);
		EnterRule(_localctx, 2, RULE_sum);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 27;
			addend();
			State = 30;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__0 || _la==T__1) {
				{
				State = 28;
				_la = TokenStream.LA(1);
				if ( !(_la==T__0 || _la==T__1) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				State = 29;
				sum();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AddendContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public MultiplierContext multiplier() {
			return GetRuleContext<MultiplierContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public AddendContext addend() {
			return GetRuleContext<AddendContext>(0);
		}
		public AddendContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_addend; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterAddend(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitAddend(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAddend(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AddendContext addend() {
		AddendContext _localctx = new AddendContext(Context, State);
		EnterRule(_localctx, 4, RULE_addend);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 32;
			multiplier();
			State = 35;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__2 || _la==T__3) {
				{
				State = 33;
				_la = TokenStream.LA(1);
				if ( !(_la==T__2 || _la==T__3) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				State = 34;
				addend();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MultiplierContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public AtomicContext[] atomic() {
			return GetRuleContexts<AtomicContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public AtomicContext atomic(int i) {
			return GetRuleContext<AtomicContext>(i);
		}
		public MultiplierContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_multiplier; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterMultiplier(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitMultiplier(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMultiplier(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MultiplierContext multiplier() {
		MultiplierContext _localctx = new MultiplierContext(Context, State);
		EnterRule(_localctx, 6, RULE_multiplier);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 37;
			atomic();
			State = 40;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==T__4) {
				{
				State = 38;
				Match(T__4);
				State = 39;
				atomic();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AtomicContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public FloatContext @float() {
			return GetRuleContext<FloatContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public CellContext cell() {
			return GetRuleContext<CellContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Enclosed_sumContext enclosed_sum() {
			return GetRuleContext<Enclosed_sumContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public IncContext inc() {
			return GetRuleContext<IncContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public DecContext dec() {
			return GetRuleContext<DecContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public MaxContext max() {
			return GetRuleContext<MaxContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public MinContext min() {
			return GetRuleContext<MinContext>(0);
		}
		public AtomicContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_atomic; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterAtomic(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitAtomic(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAtomic(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AtomicContext atomic() {
		AtomicContext _localctx = new AtomicContext(Context, State);
		EnterRule(_localctx, 8, RULE_atomic);
		try {
			State = 50;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case T__12:
			case INT:
				EnterOuterAlt(_localctx, 1);
				{
				State = 42;
				@float();
				}
				break;
			case LETTER:
				EnterOuterAlt(_localctx, 2);
				{
				State = 43;
				cell();
				}
				break;
			case T__5:
				EnterOuterAlt(_localctx, 3);
				{
				State = 44;
				enclosed_sum();
				}
				break;
			case T__7:
				EnterOuterAlt(_localctx, 4);
				{
				State = 45;
				inc();
				}
				break;
			case T__8:
				EnterOuterAlt(_localctx, 5);
				{
				State = 46;
				dec();
				}
				break;
			case T__9:
				EnterOuterAlt(_localctx, 6);
				{
				State = 47;
				max();
				}
				break;
			case T__11:
				EnterOuterAlt(_localctx, 7);
				{
				State = 48;
				min();
				}
				break;
			case Eof:
			case T__0:
			case T__1:
			case T__2:
			case T__3:
			case T__4:
			case T__6:
			case T__10:
				EnterOuterAlt(_localctx, 8);
				{
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Enclosed_sumContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum() {
			return GetRuleContext<SumContext>(0);
		}
		public Enclosed_sumContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_enclosed_sum; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterEnclosed_sum(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitEnclosed_sum(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitEnclosed_sum(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Enclosed_sumContext enclosed_sum() {
		Enclosed_sumContext _localctx = new Enclosed_sumContext(Context, State);
		EnterRule(_localctx, 10, RULE_enclosed_sum);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 52;
			Match(T__5);
			State = 53;
			sum();
			State = 54;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class IncContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum() {
			return GetRuleContext<SumContext>(0);
		}
		public IncContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_inc; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterInc(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitInc(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitInc(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public IncContext inc() {
		IncContext _localctx = new IncContext(Context, State);
		EnterRule(_localctx, 12, RULE_inc);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 56;
			Match(T__7);
			State = 57;
			sum();
			State = 58;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DecContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum() {
			return GetRuleContext<SumContext>(0);
		}
		public DecContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dec; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterDec(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitDec(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDec(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DecContext dec() {
		DecContext _localctx = new DecContext(Context, State);
		EnterRule(_localctx, 14, RULE_dec);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 60;
			Match(T__8);
			State = 61;
			sum();
			State = 62;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MaxContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public SumContext[] sum() {
			return GetRuleContexts<SumContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum(int i) {
			return GetRuleContext<SumContext>(i);
		}
		public MaxContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_max; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterMax(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitMax(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMax(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MaxContext max() {
		MaxContext _localctx = new MaxContext(Context, State);
		EnterRule(_localctx, 16, RULE_max);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 64;
			Match(T__9);
			State = 65;
			sum();
			State = 66;
			Match(T__10);
			State = 67;
			sum();
			State = 68;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MinContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public SumContext[] sum() {
			return GetRuleContexts<SumContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public SumContext sum(int i) {
			return GetRuleContext<SumContext>(i);
		}
		public MinContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_min; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterMin(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitMin(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMin(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MinContext min() {
		MinContext _localctx = new MinContext(Context, State);
		EnterRule(_localctx, 18, RULE_min);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 70;
			Match(T__11);
			State = 71;
			sum();
			State = 72;
			Match(T__10);
			State = 73;
			sum();
			State = 74;
			Match(T__6);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CellContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(SomeGrammarParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] LETTER() { return GetTokens(SomeGrammarParser.LETTER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LETTER(int i) {
			return GetToken(SomeGrammarParser.LETTER, i);
		}
		public CellContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_cell; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterCell(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitCell(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCell(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CellContext cell() {
		CellContext _localctx = new CellContext(Context, State);
		EnterRule(_localctx, 20, RULE_cell);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 76;
				Match(LETTER);
				}
				}
				State = 79;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==LETTER );
			State = 81;
			Match(INT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FloatContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] INT() { return GetTokens(SomeGrammarParser.INT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT(int i) {
			return GetToken(SomeGrammarParser.INT, i);
		}
		public FloatContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_float; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.EnterFloat(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISomeGrammarListener typedListener = listener as ISomeGrammarListener;
			if (typedListener != null) typedListener.ExitFloat(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISomeGrammarVisitor<TResult> typedVisitor = visitor as ISomeGrammarVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFloat(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FloatContext @float() {
		FloatContext _localctx = new FloatContext(Context, State);
		EnterRule(_localctx, 22, RULE_float);
		try {
			State = 89;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 83;
				Match(INT);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 84;
				Match(T__12);
				State = 85;
				Match(INT);
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 86;
				Match(INT);
				State = 87;
				Match(T__12);
				State = 88;
				Match(INT);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,16,92,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,1,0,1,0,1,0,1,1,1,1,1,1,3,1,31,
		8,1,1,2,1,2,1,2,3,2,36,8,2,1,3,1,3,1,3,3,3,41,8,3,1,4,1,4,1,4,1,4,1,4,
		1,4,1,4,1,4,3,4,51,8,4,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,
		1,8,1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,9,1,10,4,10,78,8,10,11,10,
		12,10,79,1,10,1,10,1,11,1,11,1,11,1,11,1,11,1,11,3,11,90,8,11,1,11,0,0,
		12,0,2,4,6,8,10,12,14,16,18,20,22,0,2,1,0,1,2,1,0,3,4,92,0,24,1,0,0,0,
		2,27,1,0,0,0,4,32,1,0,0,0,6,37,1,0,0,0,8,50,1,0,0,0,10,52,1,0,0,0,12,56,
		1,0,0,0,14,60,1,0,0,0,16,64,1,0,0,0,18,70,1,0,0,0,20,77,1,0,0,0,22,89,
		1,0,0,0,24,25,3,2,1,0,25,26,5,0,0,1,26,1,1,0,0,0,27,30,3,4,2,0,28,29,7,
		0,0,0,29,31,3,2,1,0,30,28,1,0,0,0,30,31,1,0,0,0,31,3,1,0,0,0,32,35,3,6,
		3,0,33,34,7,1,0,0,34,36,3,4,2,0,35,33,1,0,0,0,35,36,1,0,0,0,36,5,1,0,0,
		0,37,40,3,8,4,0,38,39,5,5,0,0,39,41,3,8,4,0,40,38,1,0,0,0,40,41,1,0,0,
		0,41,7,1,0,0,0,42,51,3,22,11,0,43,51,3,20,10,0,44,51,3,10,5,0,45,51,3,
		12,6,0,46,51,3,14,7,0,47,51,3,16,8,0,48,51,3,18,9,0,49,51,1,0,0,0,50,42,
		1,0,0,0,50,43,1,0,0,0,50,44,1,0,0,0,50,45,1,0,0,0,50,46,1,0,0,0,50,47,
		1,0,0,0,50,48,1,0,0,0,50,49,1,0,0,0,51,9,1,0,0,0,52,53,5,6,0,0,53,54,3,
		2,1,0,54,55,5,7,0,0,55,11,1,0,0,0,56,57,5,8,0,0,57,58,3,2,1,0,58,59,5,
		7,0,0,59,13,1,0,0,0,60,61,5,9,0,0,61,62,3,2,1,0,62,63,5,7,0,0,63,15,1,
		0,0,0,64,65,5,10,0,0,65,66,3,2,1,0,66,67,5,11,0,0,67,68,3,2,1,0,68,69,
		5,7,0,0,69,17,1,0,0,0,70,71,5,12,0,0,71,72,3,2,1,0,72,73,5,11,0,0,73,74,
		3,2,1,0,74,75,5,7,0,0,75,19,1,0,0,0,76,78,5,15,0,0,77,76,1,0,0,0,78,79,
		1,0,0,0,79,77,1,0,0,0,79,80,1,0,0,0,80,81,1,0,0,0,81,82,5,16,0,0,82,21,
		1,0,0,0,83,90,5,16,0,0,84,85,5,13,0,0,85,90,5,16,0,0,86,87,5,16,0,0,87,
		88,5,13,0,0,88,90,5,16,0,0,89,83,1,0,0,0,89,84,1,0,0,0,89,86,1,0,0,0,90,
		23,1,0,0,0,6,30,35,40,50,79,89
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
