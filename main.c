#include <stdio.h>

typedef struct cord_t cord

struct cord_t 
{
	double x;
	double y;
	cord *next;
};

typedef struct treangle_t treangle

struct treangle
{
	cord_t *first;
	cord_t *second;
	cord_t *third;
	treangle *next;
};

cord* add(cord *head)
{
	double test_x = 3.5;
	double test_y = 2.3;
	cord *ptr;
	ptr->x = test_x;
	ptr->y = test_y;
	ptr->next = head;
	return ptr;
}

cord* remove_one(cord *head, cord *to_remove)
{
	cord *ptr;
	if (head = to_remove)
		return head->next;
	for (ptr; ptr->next; ptr = ptr->next)
	{	
		if (ptr->next = to_remove)
		{
			//free(ptr);
			ptr = ptr->next->next;
		}
	}
	return head;
}

void *remove_all(cord *head)
{
	cord *ptr = head;
	for (;ptr;ptr = ptr->next)
	{
		cord *ptr_next = ptr->next;
		//free(ptr);
		ptr = ptr_next;
	}
}

void *change(cord *head, cord *to_change, double new_x, double new_y)
{
	cord *ptr = head;
	for (; ptr; ptr = ptr->next)
	{	
		if (ptr = to_change)
		{
			ptr->x = new_x;
			ptr->y = new_y;
		}
	}
}

cord *find_for_cord(cord *head, double x, double y)
{
	cord *ptr = head;
	for (; ptr; ptr = ptr->next)
	{	
		if (ptr->x = x && ptr->y = y)
		{
			return ptr;
		}
	}
	return NULL;
}

double find_len(cord *first, cord *second)
{
	return sqrt( sqr(first->x - second->x) + sqr(first->y - second->y) )
}

int check_treangle(cord *ptr1, cord *ptr2, cord *ptr3)
{
	double len1 = find_len(ptr1, ptr2);
	double len2 = find_len(ptr2, ptr3);
	double len3 = find_len(ptr3, ptr1);
	if (len1 + len2 > len3 && len2 + len3 > len1 && len3 + len1 > len2)
		return 0;
	else return -1;
}

treangle *make_treangles(cord *head)
{
	cord *ptr1 = head, *ptr2 = head, *ptr3 = head;
	treangle **head = NULL, *ptr;
	treangle *new_head = **head; //TODO разобраться с заголовком списка
	for (; ptr1; ptr1 = ptr1->next)
	{
		for (; ptr2; ptr2 = ptr2->next)
		{
			for (; ptr3; ptr3 = ptr3->next)
			{
				if (check_treangle(ptr1, ptr2, ptr3) == 0)
				{
					ptr = create_treangle(ptr1, ptr2, ptr3);
					if (!(*head))
					{
						*head = ptr;
					}
					else
					{
						*head->next = ptr;
						*head = *head->next;
					}
				}
			}
		}
	}
	return *head;
}

double take_one_angle(cord *first, cord *second, cord *third)
{
	//sin a = S / ab * bc
	double a = find_len(first, second);
	double b = find_len(second, third); // cord second - вершина
	double c = find_len(third, first); //медиана и высота падают на c
	double median = (1/2) * sqrt(a*a + b*b - c);
	double p = (a + b + c) / 2;
	double S = sqrt(p * (p - a) * (p - b) * (p - c));
	double height = S * c / 2;
	double ost = sqrt(median * median - height * height); //3 сторона в треугольнике с биссектрисой и медианой
	double p_ost = (median + height + ost) / 2;
	double S_ost = sqrt(p_ost * (p_ost - ost) * (p_ost - median) * (p_ost - height));
	double result = arcsin(S / height * median);
	return result;
}

double find_angle(treangle *ptr)
{
	double angle1 = take_one_angle(ptr->first, ptr->second, ptr->third);
	double angle2 = take_one_angle(ptr->second, ptr->third, ptr->first);
	double angle3 = take_one_angle(ptr->third, ptr->one, ptr->second); //TODO Проверить могут ли быть 2 угла равны и меньше чем третий одновременно
	if (angle1 <= angle2 && angle1 <= angle3)
		return angle1;
	if (angle2 <= angle1 && angle2 <= angle3)
		return angle2;
	return angle3;
}

treangle *find_min_angle(treangle *head)
{
	treangle *ptr = head, *result;
	double min = 1000;
	for (; ptr; ptr = ptr->next)
	{
		double angle = find_angle(ptr);
		if (angle < min)
		{
			min = angle;
			result = ptr;
		} 
	}
	return result;
}

int main(void)
{
	/*  1)проверить в вводе точек нет ли таких уже
		2)выделение памяти под все структуры
		3)поменять инклуды и добавить инклуды под вычисление
		4)поменять sqrt и sqr, arcsin
		5)проверить деление на ноль везде
		6)
	*/
    return 0;
}
