SELECT 
	LoginPassowd.Login_User,
	Cataloge.Thema,
	Question.Quest,
	Answer.Answ_Option as "выбор",
	(SELECT Answer.Answ_Option FROM  Result where Result.ID_RAn = RightAnswer.ID_RAn
	and RightAnswer.ID_RAn = Answer.ID_Ans) as "правильно"
FROM Cataloge, Question, Answer, RightAnswer, LoginPassowd, Result
WHERE LoginPassowd.ID = Result.ID_User
AND Cataloge.ID_Cat = Result.ID_Cat
AND Question.ID_Ques = Result.ID_Quest
AND Answer.ID_Ans = Result.ID_Answ
AND RightAnswer.ID_RAn = Result.ID_RAn

SELECT COUNT ()
FROM Question, Cataloge
WHERE  Question.ID_Cat = Cataloge.ID_Cat and Cataloge.Thema = 'ru'


SELECT
	Question.Quest,
	Answer.Answ_Option
FROM Question, Answer
INNER JOIN Cataloge ON Question.ID_Cat = Cataloge.ID_Cat
WHERE Cataloge.Thema = 'математика' AND Answer.ID_Ques = Question.ID_Ques
AND Question.Quest = '2+2=?'
AND 