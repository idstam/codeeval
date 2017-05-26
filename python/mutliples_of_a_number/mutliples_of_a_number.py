import sys

with open(sys.argv[1], 'r') as test_cases:
    for test in test_cases:
        x, n = map(int, test.split(','))

        m = n
        while (m < x):
            m += n
        print(m)
