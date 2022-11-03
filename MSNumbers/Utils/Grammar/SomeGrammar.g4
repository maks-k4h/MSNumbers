grammar SomeGrammar;

WS : [ \t\r\n]+ -> skip;  


line:           sum EOF;
sum:            addend (('+'|'-') addend)*;
addend:         multiplier (('*'|'/') multiplier)*;
multiplier:     atomic ('^' atomic)?;
atomic:         float           | 
                cell            |
                enclosed_sum    | 
                inc             |
                dec             |
                max             |
                min             |
                ;

enclosed_sum:   '(' sum ')';

inc:            'inc(' sum ')';
dec:            'dec(' sum ')';
max:            'max(' sum ',' sum ')';
min:            'min(' sum ',' sum ')';

cell:           LETTER+ INT;
float:          INT | '.' INT | INT '.' INT;
LETTER:         [A-Z] | [a-z];
INT:            [0-9]+;