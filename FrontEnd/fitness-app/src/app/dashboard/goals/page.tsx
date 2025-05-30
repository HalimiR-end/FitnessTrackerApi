'use client';

import { useState, useEffect } from 'react';
import { GoalDto } from '../../lib/types';
import apiClient from '../../lib/api/client';
import { useAuth } from '../../context/AuthContext';
import GoalCard from '../../components/ui/GoalCard';
import GoalModal from '../../components/forms/GoalModal';

export default function GoalsPage() {
  const [goals, setGoals] = useState<GoalDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { user } = useAuth();

  useEffect(() => {
    const fetchGoals = async () => {
      try {
        const response = await apiClient.get(`/goals/user/${user?.id}`);
        setGoals(response.data);
      } catch (error) {
        console.error('Failed to fetch goals', error);
      } finally {
        setLoading(false);
      }
    };

    if (user?.id) {
      fetchGoals();
    }
  }, [user?.id]);

  const handleAddGoal = async (goalData: GoalDto) => {
    try {
      const response = await apiClient.post('/goals', {
        ...goalData,
        userId: user?.id,
      });
      setGoals([...goals, response.data]);
      setIsModalOpen(false);
    } catch (error) {
      console.error('Failed to add goal', error);
    }
  };

  const handleToggleGoal = async (goalId: number, isAchieved: boolean) => {
    try {
      await apiClient.patch(`/goals/${goalId}`, { isAchieved });
      setGoals(
        goals.map((goal) =>
          goal.id === goalId ? { ...goal, isAchieved } : goal
        )
      );
    } catch (error) {
      console.error('Failed to update goal', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Your Goals</h1>
        <button
          onClick={() => setIsModalOpen(true)}
          className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
        >
          Add Goal
        </button>
      </div>

      {goals.length === 0 ? (
        <div className="text-center py-12">
          <p className="text-gray-500">No goals yet. Add your first goal!</p>
        </div>
      ) : (
        <div className="space-y-4">
          {goals.map((goal) => (
            <GoalCard
              key={goal.id}
              goal={goal}
              onToggle={handleToggleGoal}
            />
          ))}
        </div>
      )}

      <GoalModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onSubmit={handleAddGoal}
      />
    </div>
  );
}