#! python
# https://www.codeeval.com/open_challenges/114/
import argparse
import ast


def main():
    
    parser = argparse.ArgumentParser()
    parser.add_argument('filename')
    args = parser.parse_args()
    with open(args.filename) as f:
        for line in f:
            if line.strip() == "" or line.startswith("#"):
                continue
            else:
                maxWeight = getMaxWeight(line)
                products = getProducts(line, maxWeight)
                # print("In Main:  ", end="")
                # print(maxWeight, end=" ")
                # print(products)
                bestIndex = stuff(maxWeight, products)
                # print("Best index: ", end="")
                if(len(bestIndex) == 0):
                    print("-")
                else:
                    print(",".join(bestIndex))


def getMaxWeight(line):
    return int(line.split(":")[0].strip())


def getProducts(line, maxWeight):
    products = []
    rawProducts = line.split("(")
    for s in rawProducts:
        if s.strip().endswith(")"):
            t = ast.literal_eval("(" + s.replace("$", ""))
            if t[1] <= maxWeight:
                products.append(t)
    return products


def stuff(maxWeight, products):
    # index, weight, cost
    # print("maxWeight " + str(maxWeight))
    bestIndex = []
    weightOnMaxValue = 999
    maxValueFound = 0
    for sugestion in packagePermutations(products, maxWeight):
        # print("sugestion: ", end="")
        # print(sugestion)
        package = getPackage(maxWeight, sugestion)
        # print(package)

        if package[1] == maxValueFound and package[0] < weightOnMaxValue:
            weightOnMaxValue = package[0]
            bestIndex = package[2]

        if package[1] > maxValueFound:
            maxValueFound = package[1]
            weightOnMaxValue = package[0]
            bestIndex = package[2]

    return sorted(bestIndex, key=int)


def getPackage(maxWeight, sugestion):

    packWeight = 0
    packValue = 0
    products = []
    prodIndex = []
    for i in range(0, len(sugestion)):
        sWeight = sugestion[i][1]
        sValue = sugestion[i][2]
        if (sWeight + packWeight <= maxWeight) or (maxWeight < 0):
            packWeight += sWeight
            packValue += sValue
            products.append(sugestion[i])
            prodIndex.append(str(sugestion[i][0]))
        else:
            break

    return (packWeight, packValue, prodIndex)


def packagePermutations(products, maxWeight):
    # print("In perm ", end="")
    # print("maxWeight ", end="")
    # print(maxWeight, end="  ")
    # print(products)

    if not isinstance(products, list):
        return

    if len(products) == 1:
        yield products
    elif maxWeight <= 0:
        yield []
    else:
        for i in range(0, len(products)):
            newProducts = []
            newProducts.append(products[i])
            # print("A ", end="")
            # print(newProducts)
            for j in range(0, len(products)):
                if j != i:
                    newProducts.append(products[j])
                    # print("B ", end="")
                    # print(newProducts)

            head, *tail = newProducts
            for p in packagePermutations(tail, maxWeight - products[i][1]):
                yield [products[i]] + p


if __name__ == '__main__':
    main()
