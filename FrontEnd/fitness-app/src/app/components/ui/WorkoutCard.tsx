import { WorkoutDto } from '../..//lib/types';
import { format } from 'date-fns';
import Link from 'next/link';

interface WorkoutCardProps {
  workout: WorkoutDto;
}

export default function WorkoutCard({ workout }: WorkoutCardProps) {
  return (
    <Link href={`/dashboard/workouts/${workout.id}`}>
      <div className="bg-white rounded-lg shadow-md overflow-hidden hover:shadow-lg transition-shadow duration-300 cursor-pointer">
        <div className="p-6">
          <div className="flex justify-between items-start">
            <h3 className="text-lg font-semibold text-gray-900">
              {workout.name || 'Untitled Workout'}
            </h3>
            <span className="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-indigo-100 text-indigo-800">
              {format(new Date(workout.date), 'MMM dd, yyyy')}
            </span>
          </div>
          {workout.description && (
            <p className="mt-2 text-sm text-gray-600 line-clamp-2">
              {workout.description}
            </p>
          )}
          <div className="mt-4 flex justify-between items-center">
            <span className="text-sm text-gray-500">
              {/* You might want to display exercise count here */}
            </span>
            <button className="text-sm font-medium text-indigo-600 hover:text-indigo-500">
              View Details
            </button>
          </div>
        </div>
      </div>
    </Link>
  );
}