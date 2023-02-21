const ContextModelSnapshot_FilePath
	= "C\:\\Users\\GregL\\source\\repos\\KnowYourVehicle\\Infrastructure\\Data\\Migrations\\ContextModelSnapshot.cs";


const fs = require('fs');

const entityNameLine = new RegExp('[^"]*modelBuilder\\.Entity\[^"]*');
const entityBlockStart = new RegExp('[^"]*\{[^"]*');
const entityBlockEnd = new RegExp('[^"]*\}[^"]*');

const dependencyLine = new RegExp('[^"]*HasOne[^"]*');
const dependencyChainEnd = new RegExp('[^"]*;');
const foreignKeyDependency = new RegExp('[^"]*HasForeignKey[^"]*');
const deleteBehaviourLine = new RegExp('[^"]*OnDelete[^"]*');


let fileLines = [];
let entityIndex = new Map();
(async () => {
	await parseEntities(fileLines, entityIndex);
	findDependencies(fileLines, entityIndex);
})();


async function parseEntities(lines, entityIndex)
{
	try {
		let data = await fs.promises.readFile(ContextModelSnapshot_FilePath, 'utf8');

		data.split('\n').forEach(fileLine => {
			lines.push(fileLine)
		});

		let entityName;
		lines.forEach( (line, index) =>
		{
			if (entityNameLine.test(line))
			{
				entityName = line.match(/\"(.*?)\"/)[1];

				entityIndex.has(entityName)
					?entityIndex.get(entityName).push(index)
					:entityIndex.set(entityName, [index]);
			}
		});

	} catch (err) { console.log(err); }
}

function findDependencies(fileLines, entityIndex)
{
	for (let [key, value] of entityIndex)
	{
		console.log('\n'+key);
		value.forEach(lineIndex => scanEntityBlock(fileLines, lineIndex));
	}
}

function scanEntityBlock(fileLines, lineIndex)
{
	let runSwitch = 0;
	let line = fileLines[lineIndex];

	while (runSwitch == 0)
	{
		runSwitch = updateRunSwitch(runSwitch, line);
		++lineIndex;
		line = fileLines[lineIndex];
	}
		

	let dependencyName;
	let deleteBehaviour;
	let isForeignKeyDependency;
	while (runSwitch!=0)
	{
		if (dependencyLine.test(line))
		{
			dependencyName = line.match(/\"(.*?)\"/)[1];

			while (!dependencyChainEnd.test(line))
			{
				++lineIndex;
				line = fileLines[lineIndex];

				if (foreignKeyDependency.test(line))
					isForeignKeyDependency = true;

				if (deleteBehaviourLine.test(line))
					deleteBehaviour = line.match(/\((.*?)\)/)[1];
			}

			console.log(' |-DependsOn:: '+dependencyName+'\n'
				+' |- - - - - - -[isForeignKeyDependency:'+isForeignKeyDependency+']\n'
				+' |- - - - - - -['+deleteBehaviour + "]");
		}

		runSwitch = updateRunSwitch(runSwitch, line);
		++lineIndex;
		line = fileLines[lineIndex];
	}
}

function updateRunSwitch(runSwitch, lineData)
{

	if (entityBlockStart.test(lineData))
		++runSwitch;

	if (entityBlockEnd.test(lineData))
		--runSwitch;

	return runSwitch;
}