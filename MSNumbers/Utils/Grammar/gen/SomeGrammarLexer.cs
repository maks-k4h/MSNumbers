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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public partial class SomeGrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, WS=14, LETTER=15, INT=16;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "WS", "LETTER", "INT"
	};


	public SomeGrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public SomeGrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static SomeGrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,16,86,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,
		2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,7,
		14,2,15,7,15,1,0,1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,
		7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,
		11,1,11,1,11,1,11,1,11,1,12,1,12,1,13,4,13,73,8,13,11,13,12,13,74,1,13,
		1,13,1,14,3,14,80,8,14,1,15,4,15,83,8,15,11,15,12,15,84,0,0,16,1,1,3,2,
		5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,
		16,1,0,3,3,0,9,10,13,13,32,32,2,0,65,90,97,122,1,0,48,57,87,0,1,1,0,0,
		0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,
		0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,
		0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,1,33,1,0,0,0,3,35,
		1,0,0,0,5,37,1,0,0,0,7,39,1,0,0,0,9,41,1,0,0,0,11,43,1,0,0,0,13,45,1,0,
		0,0,15,47,1,0,0,0,17,52,1,0,0,0,19,57,1,0,0,0,21,62,1,0,0,0,23,64,1,0,
		0,0,25,69,1,0,0,0,27,72,1,0,0,0,29,79,1,0,0,0,31,82,1,0,0,0,33,34,5,43,
		0,0,34,2,1,0,0,0,35,36,5,45,0,0,36,4,1,0,0,0,37,38,5,42,0,0,38,6,1,0,0,
		0,39,40,5,47,0,0,40,8,1,0,0,0,41,42,5,94,0,0,42,10,1,0,0,0,43,44,5,40,
		0,0,44,12,1,0,0,0,45,46,5,41,0,0,46,14,1,0,0,0,47,48,5,105,0,0,48,49,5,
		110,0,0,49,50,5,99,0,0,50,51,5,40,0,0,51,16,1,0,0,0,52,53,5,100,0,0,53,
		54,5,101,0,0,54,55,5,99,0,0,55,56,5,40,0,0,56,18,1,0,0,0,57,58,5,109,0,
		0,58,59,5,97,0,0,59,60,5,120,0,0,60,61,5,40,0,0,61,20,1,0,0,0,62,63,5,
		44,0,0,63,22,1,0,0,0,64,65,5,109,0,0,65,66,5,105,0,0,66,67,5,110,0,0,67,
		68,5,40,0,0,68,24,1,0,0,0,69,70,5,46,0,0,70,26,1,0,0,0,71,73,7,0,0,0,72,
		71,1,0,0,0,73,74,1,0,0,0,74,72,1,0,0,0,74,75,1,0,0,0,75,76,1,0,0,0,76,
		77,6,13,0,0,77,28,1,0,0,0,78,80,7,1,0,0,79,78,1,0,0,0,80,30,1,0,0,0,81,
		83,7,2,0,0,82,81,1,0,0,0,83,84,1,0,0,0,84,82,1,0,0,0,84,85,1,0,0,0,85,
		32,1,0,0,0,4,0,74,79,84,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
