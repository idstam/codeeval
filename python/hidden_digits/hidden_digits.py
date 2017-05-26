# https://www.codeeval.com/open_challenges/122/
import argparse
import math 
def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('filename')
    args = parser.parse_args()

    with open(args.filename) as f:
        for line in f:
            if line.strip() == "":
                continue
            else:
                print(hidden(line))

def hidden(line):
    res = ""
    for c in line:
        if c in "0123456789":
            res += c
        if c in "abcdefghij":
            res += str(ord(c) - 97)

    if res == "":
        res = "NONE"

    return res

if __name__ == '__main__':
    main()