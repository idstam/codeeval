import sys
test_cases = open(sys.argv[1], 'r')
# test_cases = open('data.txt', 'r')
for test in test_cases:
    if test == '':
        continue

    rows = test.split('|')
    best =[int(s) for s in rows[0].strip().split(' ')]

    for row in rows:
        cols =[int(s) for s in row.strip().split(' ')]
        for i in range(0, len(cols) ):
            if cols[i] > best[i]:
                best[i] = cols[i]

    print(" ".join(map(str, best)))
test_cases.close()
