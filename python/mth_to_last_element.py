# https://www.codeeval.com/open_challenges/10/
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
                items = line.split(" ")
                cnt = 0
                m = 0
                for i in reversed(items):
                    if cnt == 0:
                        m = int(i)
                    elif cnt == m:
                        print(i)
                        break
                    cnt += 1


if __name__ == '__main__':
    main()