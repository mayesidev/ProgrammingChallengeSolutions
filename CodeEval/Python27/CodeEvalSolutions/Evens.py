import sys
import math

test_cases = open(sys.argv[1], 'r')
for test in test_cases:
    print (str(int(math.fabs(int(test)%2-1))))

test_cases.close()