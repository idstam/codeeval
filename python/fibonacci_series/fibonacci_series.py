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
                fibNum = int(line)
                f = fib(fibNum)
                print(int(f))

def fib(n):
    return ((1+math.sqrt(5))**n-(1-math.sqrt(5))**n)/(2**n*math.sqrt(5))

if __name__ == '__main__':
    main()