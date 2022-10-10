grammar SomeGrammar;

WS : [ \t\r\n]+ -> skip;  


line:           sum EOF;
sum:            addend (('+'|'-') sum)?;
addend:         multiplier (('*'|'/') addend)?;
multiplier:     atomic ('^' atomic)?;
atomic:         float                   | 
                '(' sum ')'             | 
                'inc''(' sum ')'        |
                'dec''(' sum ')'        |
                'max''(' sum ',' sum ')'|
                'min''(' sum ',' sum ')'|
                ;

float:          INT | '.' INT | INT '.' INT;
INT:            [0-9]+;