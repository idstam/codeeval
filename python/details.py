#  https://www.codeeval.com/open_challenges/156/
import argparse

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('filename')
    args = parser.parse_args()

    with open(args.filename) as f:
        for line in f:
            if line.strip() == "":
                continue
            else:
                print(findSmallestGap(line))        

def findSmallestGap(line):
    gapEnded = False
    gapLength = 0
    smallestGap = 100

    for c in line:
        if c == "," and gapLength < smallestGap:
            smallestGap = gapLength
        if c == "X":
            gapLength = 0
            gapEnded = False
        if c == "." and gapEnded == False:
            gapLength += 1

        if c == "Y":
            gapEnded = True

    if gapLength < smallestGap:
        smallestGap = gapLength

    return smallestGap

if __name__ == '__main__':
    main()