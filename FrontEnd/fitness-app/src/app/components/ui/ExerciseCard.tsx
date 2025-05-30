import { ExerciseDto } from '../../lib/types';

interface ExerciseCardProps {
  exercise: ExerciseDto;
}

export default function ExerciseCard({ exercise }: ExerciseCardProps) {
  return (
    <div className="bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition-shadow duration-300">
      <div className="p-6">
        <div className="flex justify-between items-start">
          <h3 className="text-lg font-semibold text-gray-900">{exercise.name}</h3>
          <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-indigo-100 text-indigo-800">
            {exercise.muscleGroup}
          </span>
        </div>
        {exercise.description && (
          <p className="mt-2 text-sm text-gray-600 line-clamp-3">
            {exercise.description}
          </p>
        )}
      </div>
    </div>
  );
}